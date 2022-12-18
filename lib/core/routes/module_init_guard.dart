import 'dart:async';

import 'package:flutter_modular/flutter_modular.dart';
import 'package:mock_interview/app.dart';

class ModuleInitGuard extends RouteGuard {
  @override
  FutureOr<bool> canActivate(String path, ParallelRoute route) async {
    await Modular.isModuleReady<AppModule>();
    return true;
  }
}
