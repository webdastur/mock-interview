import 'dart:async';

import 'package:fluent_ui/fluent_ui.dart';
import 'package:flutter_modular/flutter_modular.dart';
import 'package:mock_interview/core/bloc/user/user_cubit.dart';
import 'package:mock_interview/core/extensions/app_extensions.dart';

class LoginPageModule extends Module {
  @override
  List<ModularRoute> get routes => [
        ChildRoute(
          LoginPage.routeName,
          child: (context, args) => const LoginPage(),
        ),
      ];
}

class LoginPage extends StatefulWidget {
  static const String routeName = "/auth";

  const LoginPage({Key? key}) : super(key: key);

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  late final TextEditingController _loginController;

  late final TextEditingController _passwordController;

  @override
  void initState() {
    super.initState();
    _loginController = TextEditingController();
    _passwordController = TextEditingController();
  }

  @override
  void dispose() {
    _loginController.dispose();
    _passwordController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: ScaffoldPage.scrollable(
        header: PageHeader(
          title: const Text("Login & Register"),
          leading: IconButton(
            icon: const Icon(FluentIcons.chevron_left),
            onPressed: () {
              Modular.to.pop();
            },
          ).paddingSymmetric(horizontal: 15),
        ),
        children: [
          SizedBox(
            width: 200,
            child: Column(
              children: [
                TextBox(
                  header: 'Enter your login:',
                  placeholder: 'Login',
                  expands: false,
                  controller: _loginController,
                ),
                const SizedBox(height: 15),
                TextBox(
                  header: 'Enter your password:',
                  placeholder: 'Password',
                  expands: false,
                  obscureText: true,
                  controller: _passwordController,
                ),
                const SizedBox(height: 15),
                FilledButton(
                  child: const Text("Login"),
                  onPressed: () {
                    login();
                  },
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }

  FutureOr<void> login() async {
    UserCubit.to
        .login(
          _loginController.text,
          _passwordController.text,
        )
        .then(
          (value) => Modular.to.pop(),
        );
  }
}
