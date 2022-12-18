import 'package:equatable/equatable.dart';
import 'package:json_annotation/json_annotation.dart';

import 'experience.dart';
import 'project.dart';

part 'user.g.dart';

@JsonSerializable()
class User extends Equatable {
  @JsonKey(name: 'last_name')
  final String? lastName;
  @JsonKey(name: 'first_name')
  final String? firstName;
  @JsonKey(name: 'middle_name')
  final dynamic middleName;
  final String? phone;
  final String? login;
  final String? role;
  final dynamic image;
  final List<Experience>? experiences;
  final List<Project>? projects;
  final int? id;

  const User({
    this.lastName,
    this.firstName,
    this.middleName,
    this.phone,
    this.login,
    this.role,
    this.image,
    this.experiences,
    this.projects,
    this.id,
  });

  factory User.fromJson(Map<String, dynamic> json) => _$UserFromJson(json);

  Map<String, dynamic> toJson() => _$UserToJson(this);

  @override
  bool get stringify => true;

  @override
  List<Object?> get props {
    return [
      lastName,
      firstName,
      middleName,
      phone,
      login,
      role,
      image,
      experiences,
      projects,
      id,
    ];
  }
}
