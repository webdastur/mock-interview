import 'package:cached_network_image/cached_network_image.dart';
import 'package:fluent_ui/fluent_ui.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:infinite_scroll_pagination/infinite_scroll_pagination.dart';
import 'package:mock_interview/core/bloc/user/user_cubit.dart';
import 'package:mock_interview/core/extensions/app_extensions.dart';
import 'package:mock_interview/core/models/api/interviewer/response/interviewer_response.dart';
import 'package:mock_interview/core/routes/module_init_guard.dart';
import 'package:mock_interview/core/services/api_service.dart';
import 'package:mock_interview/core/utils/assets.gen.dart';
import 'package:mock_interview/ui/pages/login/login_page.dart';

class HomePageModule extends Module {
  @override
  List<Bind<Object>> get binds => [
        Bind.singleton<UserCubit>((i) => UserCubit()),
      ];

  @override
  List<ModularRoute> get routes => [
        ChildRoute(HomePage.routeName,
            child: (context, args) => HomePage(), guards: [ModuleInitGuard()]),
      ];
}

class HomePage extends StatefulWidget {
  static const String routeName = "/";

  HomePage({Key? key}) : super(key: key);

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  static const _pageSize = 9;

  final PagingController<int, InterviewerResponse> _pagingController =
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
      final data = await APIService.to
          .getAllInterviewers(page: pageKey, pageSize: _pageSize);

      if (data['message'] != null) {
        _pagingController.error = data['message'];
        return;
      }

      var items = (data['data']['items'] as List)
          .map((item) => InterviewerResponse.fromJson(item))
          .toList();

      final isLastPage = !data['data']['has_next_page'];
      if (isLastPage) {
        _pagingController.appendLastPage(items);
      } else {
        int nextPageKey = pageKey + items.length;
        _pagingController.appendPage(items, nextPageKey);
      }
    } catch (error) {
      _pagingController.error = error;
    }
  }

  @override
  Widget build(BuildContext context) {
    var typography = FluentTheme.of(context).typography;
    return SafeArea(
      child: ScaffoldPage.scrollable(
        header: PageHeader(
          title: const Text("Mock Interview"),
          commandBar: CommandBarCard(
            child: BlocBuilder<UserCubit, UserState>(
              bloc: UserCubit.to,
              builder: (context, state) {
                return CommandBar(
                  overflowBehavior: CommandBarOverflowBehavior.noWrap,
                  mainAxisAlignment: MainAxisAlignment.center,
                  primaryItems: [
                    CommandBarButton(
                      icon: const Icon(FluentIcons.responses_menu),
                      label: const Text("Menu"),
                      onPressed: () {
                        Modular.to.pushNamed(LoginPage.routeName);
                      },
                    ),
                    if (state.isLoggedIn)
                    const CommandBarSeparator(),
                    if (!state.isLoggedIn)
                      CommandBarButton(
                        icon: const Icon(FluentIcons.people_add),
                        label: const Text("Login & Register"),
                        onPressed: () {
                          Modular.to.pushNamed(LoginPage.routeName);
                        },
                      ),
                    if (state.isLoggedIn)
                      CommandBarButton(
                        icon: const Icon(FluentIcons.people_add),
                        label: const Text("Log Out"),
                        onPressed: () {
                          UserCubit.to.logout();
                        },
                      ),
                  ],
                );
              },
            ),
          ),
        ),
        children: [
          Assets.images.interview.image(),
          Center(
            child: Text(
              "Test your skills with our talents",
              style: typography.title,
            ).paddingOnly(top: 15),
          ),
          Text(
            "We have highly skilled talents over the world. You can test your skills with our talents. We provide detailed roadmap for you.",
            style: typography.subtitle,
            textAlign: TextAlign.center,
          ).paddingOnly(top: 15),
          PagedListView(
            pagingController: _pagingController,
            shrinkWrap: true,
            physics: const NeverScrollableScrollPhysics(),
            builderDelegate: PagedChildBuilderDelegate<InterviewerResponse>(
              itemBuilder: (context, item, index) => Container(
                width: 300,
                height: 700,
                margin: const EdgeInsets.symmetric(vertical: 10),
                child: Column(
                  children: [
                    Expanded(
                      child: CachedNetworkImage(
                        fit: BoxFit.cover,
                        imageUrl: 'https://picsum.photos/id/237/200/300',
                      ),
                    ),
                    Text(
                      item.fullName ?? "-",
                      style: typography.title,
                    ).paddingOnly(top: 15),
                  ],
                ),
              ),
            ),
          ).paddingSymmetric(vertical: 10),
        ],
      ),
    );
  }
}
