part of 'user_cubit.dart';

class UserState extends Equatable {
  final String? token;
  final bool isLoggedIn;

  const UserState({
    this.token,
    this.isLoggedIn = false,
  });

  @override
  List<Object?> get props => [token, isLoggedIn];
}
