import 'package:flutter/material.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:mock_interview/core/utils/colors.gen.dart';
import 'package:mask_text_input_formatter/mask_text_input_formatter.dart';

final phoneNumberInputFormatter = MaskTextInputFormatter(
  mask: '+998 ## ### ## ##',
  type: MaskAutoCompletionType.lazy,
);