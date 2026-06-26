<?php

require '../config.php';
require '../model/Prodotto.php';

$pdo = new PDO(
	'mysql:host=' . DB_HOST . ';dbname=' . DB_NAME . ';charset=utf8',
	DB_USER,
	DB_PASS
);

$pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
$pdo->setAttribute(PDO::ATTR_DEFAULT_FETCH_MODE, PDO::FETCH_ASSOC); //FETCH_CLASS


function getProdotti()
{
    global $pdo;

    $sql = "SELECT * FROM prodotti";

    $stmt = $pdo->query($sql);

    echo json_encode($stmt->fetchAll());
}

function getProdotto($id)
{
    global $pdo;

    $sql = "SELECT * FROM prodotti WHERE id=:id";
    
    $statement = $pdo->prepare($sql);

    $statement->execute(["id" => $id]);

    echo json_encode($statement->fetchAll());
}


function creaProdotto()
{
    global $pdo;

    $data = json_decode(file_get_contents("php://input"), true);

    $sql = "INSERT INTO prodotti
            (nome,categoria,prezzo,giacenza)
            VALUES
            (?,?,?,?)";

    $stmt = $pdo->prepare($sql);

    $stmt->execute([
        $data["nome"],
        $data["categoria"],
        $data["prezzo"],
        $data["giacenza"]
    ]);

    echo json_encode([
        "id" => $pdo->lastInsertId(),
        "messaggio" => "Prodotto creato"
    ]);
}

function modificaProdotto()
{
    global $pdo;

    $data = json_decode(file_get_contents("php://input"), true);

    $sql = "UPDATE prodotti
            SET
                nome=?,
                categoria=?,
                prezzo=?,
                giacenza=?
            WHERE id=?";

    $stmt = $pdo->prepare($sql);

    $stmt->execute([
        $data["nome"],
        $data["categoria"],
        $data["prezzo"],
        $data["giacenza"],
        $data["id"]
    ]);

    echo json_encode([
        "messaggio" => "Prodotto aggiornato"
    ]);
}