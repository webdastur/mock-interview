import 'dart:async';

import 'package:flutter_modular/flutter_modular.dart';
import 'package:isar/isar.dart';
import 'package:path_provider/path_provider.dart';

class DBService {
  static DBService get to => Modular.get<DBService>();

  late Isar isar;

  static Future<DBService> init() async {
    var instance = DBService();
    final dir = await getApplicationSupportDirectory();
    // instance.isar = await Isar.open(
    //   [
    //     ProductDBSchema,
    //     CompareDBSchema,
    //     NewsDBSchema,
    //     UserDBSchema,
    //   ],
    //   directory: dir.path,
    //   inspector: true,
    // );
    return instance;
  }
}
