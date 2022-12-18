import 'package:intl/intl.dart';

class AppHelpers {
  static String formatdMMy(DateTime dateTime) {
    final dateFormat = DateFormat('d.MM.y');
    return dateFormat.format(dateTime);
  }

  static String formatddMMyyyy(DateTime dateTime) {
    final dateFormat = DateFormat('dd.MM.yyyy');
    return dateFormat.format(dateTime);
  }

  static String moneyFormat(dynamic money) {
    if (money != null) {
      final formatCurrency =
          NumberFormat.currency(locale: "uz_UZ", symbol: '', decimalDigits: 0);
      return formatCurrency.format(money);
    }
    return '';
  }
}
