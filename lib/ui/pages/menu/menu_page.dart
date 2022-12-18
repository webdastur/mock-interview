import 'package:fluent_ui/fluent_ui.dart';
import 'package:flutter_bloc/flutter_bloc.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:mock_interview/core/bloc/navigation/navigation_cubit.dart';
import 'package:mock_interview/ui/pages/home/home_page.dart';
import 'package:mock_interview/ui/pages/interviewers/interviewers_page.dart';
import 'package:mock_interview/ui/pages/interviews/interviews_page.dart';
import 'package:mock_interview/ui/pages/users/users_page.dart';

class MenuPageModule extends Module {
  @override
  List<ModularRoute> get routes => [
        ChildRoute(
          MenuPage.routeName,
          child: (context, args) => MenuPage(),
          children: [
            ChildRoute(
              UsersPage.routeName,
              child: (context, args) => UsersPage(),
            ),
            ChildRoute(
              InterviewersPage.routeName,
              child: (context, args) => InterviewersPage(),
            ),
            ChildRoute(
              InterviewsPage.routeName,
              child: (context, args) => InterviewsPage(),
            ),
          ],
        ),
      ];
}

class MenuPage extends StatelessWidget {
  static const String routeName = "/menu";

  const MenuPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return BlocBuilder<NavigationCubit, int>(
      bloc: NavigationCubit.to,
      builder: (context, state) {
        return NavigationView(
          appBar: NavigationAppBar(
            title: Text('NavigationView'),
            leading: IconButton(
              icon: Icon(FluentIcons.chevron_left),
              onPressed: () {
                Modular.to
                    .pushNamedAndRemoveUntil(HomePage.routeName, (p0) => false);
              },
            ),
          ),
          pane: NavigationPane(
            selected: state,
            onChanged: (index) {
              NavigationCubit.to.onChanged(index);
              if (index == 0) {
                Modular.to.navigate("/menu${UsersPage.routeName}");
              }
              if (index == 1) {
                Modular.to.navigate("/menu${InterviewersPage.routeName}");
              }
              if (index == 2) {
                Modular.to.navigate("/menu${InterviewsPage.routeName}");
              }
            },
            displayMode: PaneDisplayMode.minimal,
            items: [
              PaneItem(
                icon: const Icon(FluentIcons.people),
                title: const Text('Users'),
                body: RouterOutlet(),
              ),
              PaneItem(
                icon: const Icon(FluentIcons.issue_tracking),
                title: const Text('Interviewers'),
                body: RouterOutlet(),
              ),
              PaneItem(
                icon: const Icon(FluentIcons.message),
                title: const Text('Interviews'),
                body: RouterOutlet(),
              ),
            ],
          ),
        );
      },
    );
  }
}
