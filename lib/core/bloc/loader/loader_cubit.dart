import 'package:bloc/bloc.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter_easyloading/flutter_easyloading.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:mock_interview/core/utils/colors.gen.dart';

part 'loader_state.dart';

class LoaderCubit extends Cubit<LoaderState> {
  LoaderCubit() : super(LoaderInitial()) {
    EasyLoading.instance
      ..indicatorType = EasyLoadingIndicatorType.wave
      ..backgroundColor = ColorName.green
      ..dismissOnTap = false;
  }

  static LoaderCubit get to => Modular.get<LoaderCubit>();

  void show() {
    EasyLoading.show(
      dismissOnTap: false,
      maskType: EasyLoadingMaskType.black,
    );
  }

  void hide() {
    EasyLoading.dismiss();
  }
}
