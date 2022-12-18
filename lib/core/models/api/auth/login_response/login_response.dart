import 'package:equatable/equatable.dart';
import 'package:json_annotation/json_annotation.dart';

part 'login_response.g.dart';

@JsonSerializable()
class LoginResponse extends Equatable {
  @JsonKey(name: 'access_token')
  final String? accessToken;
  @JsonKey(name: 'refresh_token')
  final String? refreshToken;
  @JsonKey(name: 'token_type')
  final String? tokenType;

  const LoginResponse({
    this.accessToken,
    this.refreshToken,
    this.tokenType,
  });

  static const fromJsonFactory = _$LoginResponseFromJson;

  Map<String, dynamic> toJson() => _$LoginResponseToJson(this);

  @override
  bool get stringify => true;

  @override
  List<Object?> get props => [accessToken, refreshToken, tokenType];
}
