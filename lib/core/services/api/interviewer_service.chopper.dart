// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'interviewer_service.dart';

// **************************************************************************
// ChopperGenerator
// **************************************************************************

// ignore_for_file: always_put_control_body_on_new_line, always_specify_types, prefer_const_declarations, unnecessary_brace_in_string_interps
class _$InterviewerService extends InterviewerService {
  _$InterviewerService([ChopperClient? client]) {
    if (client == null) return;
    this.client = client;
  }

  @override
  final definitionType = InterviewerService;

  @override
  Future<Response<ResponseModel>> getAllInterviewers(
    int page,
    int pageSize,
  ) {
    final Uri $url = Uri.parse('/Users/interviewers');
    final Map<String, dynamic> $params = <String, dynamic>{
      'Page': page,
      'PageSize': pageSize,
    };
    final Request $request = Request(
      'GET',
      $url,
      client.baseUrl,
      parameters: $params,
    );
    return client.send<ResponseModel, ResponseModel>($request);
  }
}
