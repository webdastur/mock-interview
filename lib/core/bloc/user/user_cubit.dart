import 'package:bloc/bloc.dart';
import 'package:bot_toast/bot_toast.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:mock_interview/core/services/api_service.dart';
import 'package:mock_interview/core/services/hive_service.dart';

part 'user_state.dart';

class UserCubit extends Cubit<UserState> {
  static UserCubit get to => Modular.get<UserCubit>();

  UserCubit()
      : super(UserState(
          isLoggedIn: HiveService.to.getIsLoggedIn(),
          token: HiveService.to.getToken(),
        ));

  Future login(String login, String password) async {
    var data = await APIService.to.login(
      login: login,
      password: password,
    );

    if (data['message'] != null) {
      BotToast.showText(text: data['message']);
      return;
    }

    HiveService.to
      ..setToken(data['data']['token'])
      ..setIsloggedIn(true);

    emit(UserState(token: data['data']['token'], isLoggedIn: true));
  }

  void logout() {
    HiveService.to
      ..setToken(null)
      ..setIsloggedIn(false);
    emit(const UserState(token: null, isLoggedIn: false));
  }
}
