import 'package:intl/intl.dart';

class DateUtil {
  static String ddMMyyyy(DateTime value) {
    return DateFormat('dd.MM.yyyy').format(value);
  }

  static String hhmmddMMyyyy(DateTime value) {
    return DateFormat('hh:mm dd.MM.yyyy').format(value);
  }
}
