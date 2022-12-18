part of 'loader_cubit.dart';

abstract class LoaderState extends Equatable {
  const LoaderState();
}

class LoaderInitial extends LoaderState {
  @override
  List<Object> get props => [];
}

class LoaderShow extends LoaderState {
  @override
  List<Object> get props => [];
}

class LoaderHide extends LoaderState {
  @override
  List<Object> get props => [];
}
