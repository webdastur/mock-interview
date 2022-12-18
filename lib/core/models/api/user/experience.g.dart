// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'experience.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Experience _$ExperienceFromJson(Map<String, dynamic> json) => Experience(
      name: json['name'] as String?,
      description: json['description'] as String?,
      from:
          json['from'] == null ? null : DateTime.parse(json['from'] as String),
      to: json['to'] == null ? null : DateTime.parse(json['to'] as String),
      level: json['level'],
      id: json['id'] as int?,
    );

Map<String, dynamic> _$ExperienceToJson(Experience instance) =>
    <String, dynamic>{
      'name': instance.name,
      'description': instance.description,
      'from': instance.from?.toIso8601String(),
      'to': instance.to?.toIso8601String(),
      'level': instance.level,
      'id': instance.id,
    };
