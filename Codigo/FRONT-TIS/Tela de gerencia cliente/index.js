const url = 'https://localhost:7054/api/Cliente/4';
const putUrl = 'https://localhost:7054/api/Cliente';

// Função para criar a tabela
function criarTabela(data) {
    // Verificar se a tabela já existe
    let oldTable = document.getElementById('tabela-cliente');
    if (oldTable) {
        // Remover a tabela antiga
        oldTable.remove();
    }

    // Verificar se o botão de exclusão já existe
    let oldButton = document.getElementById('botao-excluir');
    if (oldButton) {
        // Remover o botão de exclusão antigo
        oldButton.remove();
    }

    // Criar nova tabela
    let table = document.createElement('table');
    table.id = 'tabela-cliente';

    // Criar cabeçalho da tabela
    let thead = document.createElement('thead');
    let headerRow = document.createElement('tr');

    // Adicionar colunas ao cabeçalho
    let keys = ["nome", "dataNasci", "endereco", "telefone", "email", "senha"];
    let columnNames = ["Nome", "Data de nascimento", "Endereço", "Telefone", "E-mail", "Senha"];
    for (let i = 0; i < keys.length; i++) {
        let th = document.createElement('th');
        th.textContent = columnNames[i];
        headerRow.appendChild(th);
    }

    thead.appendChild(headerRow);
    table.appendChild(thead);

    // Criar corpo da tabela
    let tbody = document.createElement('tbody');
    let dataRow = document.createElement('tr');

    // Adicionar dados à linha
    for (let key of keys) {
        let td = document.createElement('td');
        let text = document.createTextNode(data.dados[key]);
        let originalText = text.nodeValue; // Armazenar o valor do texto original
        td.appendChild(text);

        // Adicionar botão de edição
        let editButton = document.createElement('button');
editButton.textContent = 'Editar';
editButton.addEventListener('click', function() {
    // Substituir texto por campo de entrada
    let input = document.createElement('input');
    input.type = 'text';
    input.value = originalText; // Usar o valor do texto original
    input.addEventListener('blur', function() {
        // Atualizar dados quando o campo de entrada perde o foco
        let inputValue = input.value !== '' ? input.value : originalText;
        fetch(putUrl, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                ...data.dados,
                [key]: inputValue
            })
        })
        .then(response => response.json())
        .then(updatedData => {
            // Atualizar texto
            originalText = inputValue; // Usar o valor do campo de entrada
            text.nodeValue = originalText; // Atualizar o valor do texto na tabela
            // Substituir campo de entrada por texto
            if (td.contains(input)) {
                td.replaceChild(text, input);
            }
        })
        .catch(error => console.error('Erro:', error));
    });

    if (td.contains(text)) {
        td.replaceChild(input, text);
    }
    input.focus();
});

td.appendChild(editButton);
dataRow.appendChild(td);
}

    tbody.appendChild(dataRow);
    table.appendChild(tbody);

    // Adicionar tabela ao documento
    document.body.appendChild(table);

    // Criar contêiner para o botão de exclusão
    let buttonContainer = document.createElement('div');
    buttonContainer.style.display = 'flex';
    buttonContainer.style.justifyContent = 'center';
    buttonContainer.style.marginTop = '20px';

    // Criar botão de exclusão
    let deleteButton = document.createElement('button');
    deleteButton.id = 'botao-excluir';
    deleteButton.textContent = 'Excluir conta';
    deleteButton.addEventListener('click', function() {
        // Enviar solicitação DELETE para a API
        fetch(`https://localhost:7054/api/Cliente/string?email=${data.dados.email}`, { method: 'DELETE' })
            .then(response => {
                if (response.ok) {
                    // Remover tabela
                    table.remove();
                    // Remover botão de exclusão
                    deleteButton.remove();
                } else {
                    console.error('Erro ao excluir conta:', response.statusText);
                }
            })
            .catch(error => console.error('Erro:', error));
    });

    // Adicionar botão de exclusão ao contêiner
    buttonContainer.appendChild(deleteButton);

    // Adicionar contêiner do botão de exclusão abaixo da tabela
    document.body.appendChild(buttonContainer);
}

// Adicionar evento de clique ao botão
document.getElementById('meu-botao').addEventListener('click', function() {
    // Verificar se a tabela já existe
    let table = document.getElementById('tabela-cliente');
    if (table) {
        // Se a tabela já existe, removê-la
        table.remove();
        // Remover também o botão de exclusão
        document.getElementById('botao-excluir').remove();
    } else {
        // Se a tabela não existe, obter dados do cliente da API
        fetch(url)
            .then(response => response.json())
            .then(data => {
                // Criar tabela com os dados
                criarTabela(data);
            })
            .catch(error => console.error('Erro:', error));
    }
});
