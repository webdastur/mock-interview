import 'package:equatable/equatable.dart';
import 'package:json_annotation/json_annotation.dart';

part 'login_request.g.dart';

@JsonSerializable()
class LoginRequest extends Equatable {
  @JsonKey(name: "phone_number")
  final String phoneNumber;
  final String password;

  const LoginRequest({
    required this.phoneNumber,
    required this.password,
  });

  static const fromJsonFactory = _$LoginRequestFromJson;

  Map<String, dynamic> toJson() => _$LoginRequestToJson(this);

  @override
  bool get stringify => true;

  @override
  List<Object?> get props => [phoneNumber, password];
}
