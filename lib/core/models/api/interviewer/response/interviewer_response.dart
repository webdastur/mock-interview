import 'package:equatable/equatable.dart';
import 'package:json_annotation/json_annotation.dart';

part 'interviewer_response.g.dart';

@JsonSerializable()
class InterviewerResponse extends Equatable {
  final String? phone;
  final String? role;
  @JsonKey(name: 'full_name')
  final String? fullName;
  final int? id;

  const InterviewerResponse({
    this.phone,
    this.role,
    this.fullName,
    this.id,
  });

  static const fromJsonFactory = _$InterviewerResponseFromJson;

  factory InterviewerResponse.fromJson(Map<String, dynamic> json) {
    return _$InterviewerResponseFromJson(json);
  }

  Map<String, dynamic> toJson() => _$InterviewerResponseToJson(this);

  InterviewerResponse copyWith({
    String? phone,
    String? role,
    String? fullName,
    int? id,
  }) {
    return InterviewerResponse(
      phone: phone ?? this.phone,
      role: role ?? this.role,
      fullName: fullName ?? this.fullName,
      id: id ?? this.id,
    );
  }

  @override
  bool get stringify => true;

  @override
  List<Object?> get props => [phone, role, fullName, id];
}
