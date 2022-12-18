import 'package:equatable/equatable.dart';
import 'package:json_annotation/json_annotation.dart';

class ResponseModel<T> extends Equatable {
  final T? data;
  @JsonKey(name: 'status_code')
  final int? statusCode;
  final dynamic message;

  const ResponseModel({this.data, this.statusCode, this.message});

  factory ResponseModel.fromJson(Map<String, dynamic> json) {
    return ResponseModel(
      data: json['data'],
      statusCode: json['status_code'],
      message: json['message'],
    );
  }

  @override
  bool get stringify => true;

  @override
  List<Object?> get props => [data, statusCode, message];
}
