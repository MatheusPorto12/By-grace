document.querySelector('.form-cadastro').addEventListener('submit', function(event) {
    event.preventDefault(); // Para prevenir o comportamento padrão do formulário

    let senha = document.getElementById('senha').value;
    let senhaConfirm = document.getElementById('senhaConfirm').value;

    if (senha !== senhaConfirm) {
        alert('As senhas não coincidem. Por favor, verifique e tente novamente.');
        return;
    }

    let cliente = {
        nome: document.getElementById('nome').value,
        cpf: document.getElementById('cpf').value,
        telefone: document.getElementById('telefone').value,
        data_nascimento: document.getElementById('data_nascimento').value,
        email: document.getElementById('email').value,
        endereco: document.getElementById('cep').value + ', ' +
                  document.getElementById('bairro').value + ', ' +
                  document.getElementById('rua').value + ', ' +
                  document.getElementById('numero').value + ', ' +
                  document.getElementById('complemento').value,
        senha: senha,
    };

    fetch('https://localhost:7054/api/Cliente', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(cliente),
    })
    .then(response => response.json())
    .then(data => console.log(data))
    .catch((error) => {
        console.error('Error:', error);
    });
});
