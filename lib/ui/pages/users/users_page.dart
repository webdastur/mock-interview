import 'package:fluent_ui/fluent_ui.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:infinite_scroll_pagination/infinite_scroll_pagination.dart';
import 'package:mock_interview/core/extensions/app_extensions.dart';
import 'package:mock_interview/core/models/api/user/user.dart';
import 'package:mock_interview/core/services/api_service.dart';

class UsersPageModule extends Module {}

class UsersPage extends StatefulWidget {
  static const String routeName = "/users";

  const UsersPage({Key? key}) : super(key: key);

  @override
  State<UsersPage> createState() => _UsersPageState();
}

class _UsersPageState extends State<UsersPage> {
  static const _pageSize = 9;

  final PagingController<int, User> _pagingController =
      PagingController(firstPageKey: 0);

  @override
  void initState() {
    _pagingController.addPageRequestListener((pageKey) {
      _fetchPage(pageKey);
    });
    super.initState();
  }

  Future<void> _fetchPage(int pageKey) async {
    try {
      final data =
          await APIService.to.getAllUsers(page: pageKey, pageSize: _pageSize);

      if (data['message'] != null) {
        _pagingController.error = data['message'];
        return;
      }

      var items = (data['data']['items'] as List)
          .map((item) => User.fromJson(item))
          .toList();

      final isLastPage = !data['data']['has_next_page'];
      if (isLastPage) {
        _pagingController.appendLastPage(items);
      } else {
        int nextPageKey = pageKey + items.length;
        _pagingController.appendPage(items, nextPageKey);
      }
    } catch (error) {
      print(error);
      _pagingController.error = error;
    }
  }

  @override
  Widget build(BuildContext context) {
    var typography = FluentTheme.of(context).typography;
    return ScaffoldPage(
      header: const PageHeader(
        title: Text("Users"),
      ),
      content: PagedListView(
        pagingController: _pagingController,
        builderDelegate: PagedChildBuilderDelegate<User>(
          itemBuilder: (context, item, index) => Row(
            children: [
              Text("${index + 1}. | ", style: typography.title),
              Text("${item.firstName} ${item.lastName} | ",
                  style: typography.title),
              Text("${item.role}", style: typography.title),
              const Spacer(),
              IconButton(
                icon: const Icon(
                  FluentIcons.edit,
                  size: 30,
                ),
                onPressed: () {
                  APIService.to.deleteUser(item.id??-1).then((value) {
                    _pagingController.refresh();
                  });
                },
              ),
              IconButton(
                icon: Icon(
                  FluentIcons.delete,
                  color: Colors.red,
                  size: 30,
                ),
                onPressed: () {},
              ),
            ],
          ).paddingAll(10),
        ),
      ),
    );
  }
}
