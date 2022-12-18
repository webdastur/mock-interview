import 'package:equatable/equatable.dart';
import 'package:json_annotation/json_annotation.dart';

part 'app_error.g.dart';

@JsonSerializable()
class AppError extends Equatable {
  final String error;
  final int status;

  const AppError({
    required this.error,
    required this.status,
  });

  static const fromJsonFactory = _$AppErrorFromJson;

  Map<String, dynamic> toJson() => _$AppErrorToJson(this);

  @override
  bool get stringify => true;

  @override
  List<Object?> get props => [error, status];
}
