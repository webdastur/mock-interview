// import 'package:flutter/material.dart';
// import 'package:uznn/ui/change_language/change_language.dart';
// import 'package:uznn/ui/change_phone_number/change_phone_number.dart';
// import 'package:uznn/ui/counter/counter.dart';
// import 'package:uznn/ui/edit_profile/view/edit_profile_page.dart';
// import 'package:uznn/ui/exclusive/exclusive.dart';
// import 'package:uznn/ui/favourites/favourites.dart';
// import 'package:uznn/ui/home/home.dart';
// import 'package:uznn/ui/language/language.dart';
// import 'package:uznn/ui/main/main.dart';
// import 'package:uznn/ui/payment/payment.dart';
// import 'package:uznn/ui/phone_number/phone_number.dart';
// import 'package:uznn/ui/phone_verification/phone_verification.dart';
// import 'package:uznn/ui/product_detail/product_detail.dart';
// import 'package:uznn/ui/profile/profile.dart';
// import 'package:uznn/ui/register/view/register_page.dart';
//
// class AppRouteUtil {
//   // ignore: missing_return
//   static Route<dynamic>? generateRoute(RouteSettings settings) {
//     // final args = settings.arguments;
//
//     switch (settings.name) {
//       case CounterPage.routeName:
//         return MaterialPageRoute<CounterPage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => CounterPage(),
//         );
//       case LanguagePage.routeName:
//         return MaterialPageRoute<LanguagePage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => LanguagePage(),
//         );
//       case PhoneNumberPage.routeName:
//         return MaterialPageRoute<PhoneNumberPage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => PhoneNumberPage(),
//         );
//       case PhoneVerificationPage.routeName:
//         return MaterialPageRoute<PhoneVerificationPage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => PhoneVerificationPage(
//             phoneNumber: settings.arguments! as String,
//           ),
//         );
//       case HomePage.routeName:
//         return MaterialPageRoute<HomePage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => HomePage(),
//         );
//       case ProductDetailPage.routeName:
//         return MaterialPageRoute<ProductDetailPage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => ProductDetailPage(
//             productDetailId: settings.arguments as int,
//           ),
//         );
//       case FavouritesPage.routeName:
//         return MaterialPageRoute<FavouritesPage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => FavouritesPage(),
//         );
//       case MainPage.routeName:
//         return MaterialPageRoute<MainPage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => MainPage(
//             isCurrencyOpen: (settings.arguments as bool?) ?? false,
//           ),
//         );
//       case ProfilePage.routeName:
//         return MaterialPageRoute<ProfilePage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => ProfilePage(),
//         );
//       case PaymentPage.routeName:
//         return MaterialPageRoute<PaymentPage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => PaymentPage(),
//         );
//       case ExclusivePage.routeName:
//         return MaterialPageRoute<ExclusivePage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => ExclusivePage(),
//         );
//       case RegisterPage.routeName:
//         return MaterialPageRoute<RegisterPage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => RegisterPage(
//             phoneNumber: settings.arguments! as String,
//           ),
//         );
//       case ChangeLanguagePage.routeName:
//         return MaterialPageRoute<ChangeLanguagePage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => ChangeLanguagePage(),
//         );
//       case EditProfilePage.routeName:
//         return MaterialPageRoute<EditProfilePage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => EditProfilePage(
//             parameter: settings.arguments! as EditProfilePageParameter,
//           ),
//         );
//       case ChangePhoneNumberPage.routeName:
//         return MaterialPageRoute<ChangePhoneNumberPage>(
//           // ignore: prefer_const_constructors
//           builder: (_) => ChangePhoneNumberPage(),
//         );
//     }
//     return null;
//   }
// }
