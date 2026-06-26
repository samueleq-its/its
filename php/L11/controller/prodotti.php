<?php

require "../db/db.php";

switch ($method) {

    case "GET":

        if ($id) {
            getProdotto($id);
        } else {
            getProdotti();
        }

        break;

    case "POST":

        creaProdotto();

        break;

    case "PUT":

        aggiornaProdotto($id);

        break;

    case "DELETE":

        eliminaProdotto($id);

        break;
}