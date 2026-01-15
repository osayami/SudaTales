import 'package:flutter/material.dart';

void main() {
  runApp(const SudaTalesApp());
}

class SudaTalesApp extends StatelessWidget {
  const SudaTalesApp({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      debugShowCheckedModeBanner: false,
      home: Scaffold(
        body: Center(
          child: Text('Sudatales'),
        ),
      ),
    );
  }
}
