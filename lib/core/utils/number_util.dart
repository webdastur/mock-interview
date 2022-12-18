import 'package:intl/intl.dart';

class NumberUtil {
  static String priceFormat(double price) {
    return NumberFormat("###,###,###,###").format(price);
  }
}
