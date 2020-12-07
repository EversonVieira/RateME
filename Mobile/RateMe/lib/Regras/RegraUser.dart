import 'package:RateMe/Classes/User.dart';
import 'package:RateMe/Services/UserService.dart';

UserService userService = new UserService();

class RegraUser {
  int cadastrar(User user) {
    int retorno = 0;
    userService
        .cadastrar(user)
        .then((value) => retorno = int.parse(retorno.toString()));
  }
}
