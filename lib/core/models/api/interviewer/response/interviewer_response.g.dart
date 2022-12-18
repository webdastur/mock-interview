// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'interviewer_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

InterviewerResponse _$InterviewerResponseFromJson(Map<String, dynamic> json) =>
    InterviewerResponse(
      phone: json['phone'] as String?,
      role: json['role'] as String?,
      fullName: json['full_name'] as String?,
      id: json['id'] as int?,
    );

Map<String, dynamic> _$InterviewerResponseToJson(
        InterviewerResponse instance) =>
    <String, dynamic>{
      'phone': instance.phone,
      'role': instance.role,
      'full_name': instance.fullName,
      'id': instance.id,
    };
