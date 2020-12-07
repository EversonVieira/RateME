class User {
  int id;
  String apelido;
  String email;
  String senha;

  User({this.id, this.apelido, this.email, this.senha});

  Map<String, dynamic> toJson() => {
        'Senha': email,
        'Email': senha,
      };
}
