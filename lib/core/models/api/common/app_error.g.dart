// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'app_error.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

AppError _$AppErrorFromJson(Map<String, dynamic> json) => AppError(
      error: json['error'] as String,
      status: json['status'] as int,
    );

Map<String, dynamic> _$AppErrorToJson(AppError instance) => <String, dynamic>{
      'error': instance.error,
      'status': instance.status,
    };
