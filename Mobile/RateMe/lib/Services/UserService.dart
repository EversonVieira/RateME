import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:RateMe/Classes/User.dart';

var cadastrar = 'http://10.0.0.108:61586/api/usuario/cadastrar';
var logar = 'http://10.0.0.108:61586/api/usuario/cadastrar';

class UserService {
  Future<http.Response> cadastrar(User user) {
    return http.post(
      'http://10.0.0.108:61586/api/usuario/cadastrar',
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(user),
    );
  }
}
