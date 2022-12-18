import 'package:fluent_ui/fluent_ui.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:mock_interview/core/utils/assets.gen.dart';
import 'package:mock_interview/ui/pages/home/home_page.dart';

class NotFoundPageModule extends Module {
  @override
  List<ModularRoute> get routes => [
        WildcardRoute(
          child: (context, args) => const NotFoundPage(),
        ),
      ];
}

class NotFoundPage extends StatelessWidget {
  static const String routeName = "/not-found";

  const NotFoundPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    var typography = FluentTheme.of(context).typography;
    return SafeArea(
      child: ScaffoldPage.scrollable(
        header: const PageHeader(
          title: Text("Not Found"),
        ),
        children: [
          Center(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                Container(
                  width: 450,
                  padding: const EdgeInsets.all(50),
                  child: Column(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      Text(
                        "Not Found",
                        style: typography.title,
                      ),
                      const SizedBox(height: 15),
                      const SelectableText(
                        "We can't find that page.",
                      ),
                      const SizedBox(height: 15),
                      Assets.images.notFound.image(
                        width: 300,
                        height: 300,
                      ),
                      const SizedBox(height: 15),
                      FilledButton(
                        child: Text(
                          "Return to home",
                          style: typography.title,
                        ),
                        onPressed: () {
                          Modular.to.pushNamedAndRemoveUntil(
                              HomePage.routeName, (p0) => false);
                        },
                      ),
                    ],
                  ),
                ),
              ],
            ),
          )
        ],
      ),
    );
  }
}
