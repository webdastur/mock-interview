import 'package:chopper/chopper.dart';
import 'package:mock_interview/core/models/api/common/response_model/response_model.dart';

part 'interviewer_service.chopper.dart';

@ChopperApi()
abstract class InterviewerService extends ChopperService {
  static InterviewerService create([
    ChopperClient? client,
  ]) =>
      _$InterviewerService(client);

  @Get(path: "/Users/interviewers")
  Future<Response<ResponseModel>> getAllInterviewers(
    @Query("Page") int page,
    @Query("PageSize") int pageSize,
  );
}
