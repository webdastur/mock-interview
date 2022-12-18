import 'dart:ui';

import 'package:flutter_modular/flutter_modular.dart';
import 'package:hive/hive.dart';

class HiveService {
  static HiveService get to => Modular.get<HiveService>();

  late Box _box;

  static Future<HiveService> init() async {
    var instance = HiveService();

    instance._box = await Hive.openBox("mock_interview");

    return instance;
  }

  Future delete() async {
    await Hive.deleteFromDisk();
  }

  bool getIsLoggedIn() {
    return _box.get(_HiveKeys.isLoggedIn, defaultValue: false);
  }

  void setIsloggedIn(bool value) {
    _box.put(_HiveKeys.isLoggedIn, value);
  }

  String? getTemporaryToken() {
    return _box.get(_HiveKeys.temporaryToken, defaultValue: null);
  }

  void setTemporaryToken(String? value) {
    _box.put(_HiveKeys.temporaryToken, value);
  }

  String? getToken() {
    return _box.get(_HiveKeys.token, defaultValue: null);
  }

  void setToken(String? value) {
    _box.put(_HiveKeys.token, value);
  }

  void setExpiration(DateTime value) {
    _box.put(_HiveKeys.expiration, value);
  }

  DateTime? getExpiration() {
    return _box.get(_HiveKeys.expiration);
  }
}

class _HiveKeys {
  static const String isLoggedIn = "isLoggedIn";
  static const String temporaryToken = "temporaryToken";
  static const String token = "token";
  static const String expiration = "expiration";
}
