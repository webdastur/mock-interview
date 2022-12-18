import 'dart:async';

import 'package:flutter_modular/flutter_modular.dart';
import 'package:mock_interview/core/services/hive_service.dart';

class GuestGuard extends RouteGuard {
  GuestGuard()
      : super(
          redirectTo: '/',
        );

  @override
  FutureOr<bool> canActivate(String path, ParallelRoute route) async {
    return !Modular.get<HiveService>().getIsLoggedIn();
  }
}
