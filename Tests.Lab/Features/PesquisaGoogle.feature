#language: pt-BR
#Author: Lucas Fraga
#Date: 12/06/2017
#Version: 0.10

@chrome
Funcionalidade: Pesquisar no Google

Cenario: Pesquisar no Google com sucesso
	Dado que eu esteja no site do Google
	Quando realizar uma pesquisa
	Entao vejo mensagem com sucesso
	
