import 'package:bot_toast/bot_toast.dart';
import 'package:fluent_ui/fluent_ui.dart';
import 'package:flutter_acrylic/flutter_acrylic.dart' as flutter_acrylic;
import 'package:flutter_easyloading/flutter_easyloading.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:mock_interview/core/bloc/loader/loader_cubit.dart';
import 'package:mock_interview/core/bloc/navigation/navigation_cubit.dart';
import 'package:mock_interview/core/services/api_service.dart';
import 'package:mock_interview/core/services/hive_service.dart';
import 'package:mock_interview/theme.dart';
import 'package:mock_interview/ui/pages/home/home_page.dart';
import 'package:mock_interview/ui/pages/login/login_page.dart';
import 'package:mock_interview/ui/pages/menu/menu_page.dart';
import 'package:mock_interview/ui/pages/not_found/not_found_page.dart';
import 'package:provider/provider.dart' as p;
import 'package:responsive_framework/responsive_framework.dart';

class App extends StatelessWidget {
  App({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    Modular.setInitialRoute(
      HomePage.routeName,
    );
    Modular.setObservers([BotToastNavigatorObserver()]);

    return p.ChangeNotifierProvider(
        create: (_) => AppTheme(),
        builder: (context, _) {
          final appTheme = p.Provider.of<AppTheme>(context);
          return FluentApp.router(
            title: "Mock Interview",
            debugShowCheckedModeBanner: false,
            themeMode: appTheme.mode,
            builder: builder,
            color: appTheme.color,
            darkTheme: ThemeData(
              brightness: Brightness.dark,
              accentColor: appTheme.color,
              visualDensity: VisualDensity.standard,
              scaffoldBackgroundColor: const Color(0xFF272727),
              focusTheme: FocusThemeData(
                glowFactor: is10footScreen() ? 2.0 : 0.0,
              ),
            ),
            theme: ThemeData(
              accentColor: appTheme.color,
              visualDensity: VisualDensity.standard,
              scaffoldBackgroundColor: const Color(0xFF272727),
              focusTheme: FocusThemeData(
                glowFactor: is10footScreen() ? 2.0 : 0.0,
              ),
            ),
            routeInformationParser: Modular.routeInformationParser,
            routerDelegate: Modular.routerDelegate,
          );
        });
  }

  Widget builder(BuildContext context, Widget? child) {
    child = ResponsiveWrapper.builder(
      BouncingScrollWrapper.builder(context, child!),
      // maxWidth: 1200,
      minWidth: 450,
      defaultScale: true,
      breakpoints: [
        const ResponsiveBreakpoint.resize(450, name: MOBILE),
        const ResponsiveBreakpoint.autoScale(800, name: TABLET),
        const ResponsiveBreakpoint.autoScale(1000, name: TABLET),
        const ResponsiveBreakpoint.resize(1200, name: DESKTOP),
        const ResponsiveBreakpoint.autoScale(2460, name: "4K"),
      ],
      background: Container(
        color: const Color(0xFFF5F5F5),
      ),
    );
    return NavigationPaneTheme(
      data: NavigationPaneThemeData(
        backgroundColor: p.Provider.of<AppTheme>(context).windowEffect !=
                flutter_acrylic.WindowEffect.disabled
            ? Colors.transparent
            : null,
      ),
      child: EasyLoading.init(
        builder: BotToastInit(),
      )(context, child),
    );
  }
}

void rebuildAllChildren(BuildContext context) {
  void rebuild(Element el) {
    el.markNeedsBuild();
    el.visitChildren(rebuild);
  }

  (context as Element).visitChildren(rebuild);
}

class AppModule extends Module {
  @override
  List<Bind<Object>> get binds => [
        // Bind.singleton<HttpService>((i) => HttpService.init()),
        AsyncBind<HiveService>((i) => HiveService.init()),
        Bind.lazySingleton((i) => APIService.init()),
        // Bind.lazySingleton<AuthService>((i) => AuthService()),
        // Bind.lazySingleton<ProfileService>((i) => ProfileService()),
        // Bind.lazySingleton<CurrencyService>((i) => CurrencyService()),
        // Bind.lazySingleton<ProductService>((i) => ProductService()),
        // Bind.lazySingleton<AdsService>((i) => AdsService()),
        // Bind.lazySingleton<PaymentService>((i) => PaymentService()),
        // Bind.lazySingleton<TariffService>((i) => TariffService()),
        // Bind.lazySingleton<NewsService>((i) => NewsService()),
        Bind.singleton<NavigationCubit>((i) => NavigationCubit()),
        Bind<LoaderCubit>(
          (i) => LoaderCubit(),
          onDispose: (v) => v.close(),
        ),
      ];

  @override
  List<ModularRoute> get routes => [
        ModuleRoute('/', module: NotFoundPageModule()),
        ModuleRoute('/', module: HomePageModule()),
        ModuleRoute('/', module: LoginPageModule()),
        ModuleRoute('/', module: MenuPageModule()),
        // ModuleRoute('/', module: EditProfilePageModule()),
        // ModuleRoute('/', module: ExclusivePageModule()),
        // ModuleRoute('/', module: FavouritesPageModule()),
        // ModuleRoute('/', module: MainPageModule()),
        // ModuleRoute('/', module: PaymentPageModule()),
        // ModuleRoute('/', module: PhoneNumberPageModule()),
        // ModuleRoute('/', module: PhoneVerificationPageModule()),
        // ModuleRoute('/', module: ProductDetailPageModule()),
        // ModuleRoute('/', module: ProfilePageModule()),
        // ModuleRoute('/', module: PaymentWebModule()),
        // ModuleRoute('/', module: RegisterPageModule()),
        // ModuleRoute('/', module: ComparePageModule()),
        // ModuleRoute('/', module: TariffPageModule()),
        // ModuleRoute('/', module: NewsPageModule()),
        // ModuleRoute('/', module: NewsDetailPageModule()),
        // ModuleRoute('/', module: LawDescriptionModule()),
        // ModuleRoute('/', module: CurrencyModule()),
        // ModuleRoute('/', module: SavedNewsPageModule()),
      ];
}
