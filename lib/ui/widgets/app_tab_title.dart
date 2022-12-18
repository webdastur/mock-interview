import 'package:flutter/material.dart';
import 'package:mock_interview/core/utils/colors.gen.dart';

class AppTabTitle extends StatelessWidget {
  const AppTabTitle({
    Key? key,
    required this.child,
    required this.title,
  }) : super(key: key);

  final Widget child;
  final String title;

  @override
  Widget build(BuildContext context) {
    return Title(
      title: "$title | Mock Interview",
      color: ColorName.white,
      child: child,
    );
  }
}
