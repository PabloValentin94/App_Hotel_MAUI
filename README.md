# Aplicativo de Simulação de Hospedagem de Hotel

O objetivo desse aplicativo é simular o cálculo de uma hospedagem em um hotel.

## Autenticação Básica

Ao iniciar o aplicativo pela primeira vez, é exigido um cadastro para efetuar o login, porém os dados são salvos em uma variável global do aplicativo, ou seja, não são acessíveis externamente, como em um banco de dados, por exemplo. Também é possível remover a autenticação, utilizando o botão "Logout".

## Cálculo de Custos

Após a autenticação, é exibida uma página que requisita dados para o cálculo da hospedagem desejada. São eles:

1. Hóspedes

    - Quantidade de Adultos;
    - Quantidade de Crianças.

2. Quarto Desejado

3. Estadia

    - Data de Entrada (Check-In);
    - Data de Saída (Check-out).

## Exibição de Custos

Após fornecer os dados solicitados, o usuário pode clicar no botão "Calcular", que navegará para uma página onde serão exibidos os seguintes resultados:

1. Quantidade de Hóspedes

    - Adultos;
    - Crianças.

2. Datas Especificadas

    - Check-In;
    - Check-out.

3. Estadia Total (Dias)

4. Custo Total (R$)

## Verificações

Algumas travas foram adicionadas na página de cálculo de custos. São elas:

- A data de check-in deve ser, no mínimo, um dia após a data atual;
- A data de check-in pode ser, no máximo, um mês após a data atual;
- A data de check-out pode ser, no máximo, dois meses após a data de check-in selecionada.

Tudo isso é recalculado toda vez que a data de check-in for alterada.
