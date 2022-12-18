import 'package:chopper/chopper.dart';
import 'package:mock_interview/core/models/api/auth/login_request/login_request.dart';
import 'package:mock_interview/core/models/api/auth/login_response/login_response.dart';

part 'auth_service.chopper.dart';

@ChopperApi()
abstract class AuthService extends ChopperService {
  static AuthService create([
    ChopperClient? client,
  ]) =>
      _$AuthService(client);

  @Post(path: "/login")
  Future<Response<LoginResponse>> login(
    @Body() LoginRequest data,
  );
}
