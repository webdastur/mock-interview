import 'package:equatable/equatable.dart';
import 'package:json_annotation/json_annotation.dart';

part 'project.g.dart';

@JsonSerializable()
class Project extends Equatable {
  final String? name;
  final String? description;
  final String? url;
  final dynamic image;
  final int? id;

  const Project({
    this.name,
    this.description,
    this.url,
    this.image,
    this.id,
  });

  factory Project.fromJson(Map<String, dynamic> json) {
    return _$ProjectFromJson(json);
  }

  Map<String, dynamic> toJson() => _$ProjectToJson(this);

  @override
  bool get stringify => true;

  @override
  List<Object?> get props => [name, description, url, image, id];
}
