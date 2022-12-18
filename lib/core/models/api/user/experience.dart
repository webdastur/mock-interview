import 'package:equatable/equatable.dart';
import 'package:json_annotation/json_annotation.dart';

part 'experience.g.dart';

@JsonSerializable()
class Experience extends Equatable {
  final String? name;
  final String? description;
  final DateTime? from;
  final DateTime? to;
  final dynamic level;
  final int? id;

  const Experience({
    this.name,
    this.description,
    this.from,
    this.to,
    this.level,
    this.id,
  });

  factory Experience.fromJson(Map<String, dynamic> json) {
    return _$ExperienceFromJson(json);
  }

  Map<String, dynamic> toJson() => _$ExperienceToJson(this);

  @override
  bool get stringify => true;

  @override
  List<Object?> get props => [name, description, from, to, level, id];
}
