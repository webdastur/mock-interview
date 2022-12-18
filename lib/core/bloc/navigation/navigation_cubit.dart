import 'package:bloc/bloc.dart';
import 'package:flutter_modular/flutter_modular.dart';

class NavigationCubit extends Cubit<int> {
  static NavigationCubit get to => Modular.get<NavigationCubit>();

  NavigationCubit() : super(0);

  void onChanged(int value) {
    emit(value);
  }
}
