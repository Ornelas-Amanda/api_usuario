<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Database\Eloquent\Model;

class Usuario extends Model
{
    use HasFactory;

    //Define os campos para os atribuirem em massa
    protected $fillable = ['Nome',"Sobrenome",'Email','Dt','Escolaridade'];
 
    // Aplicando regras de validação
    public function Regras(){
        $hoje =date('Y-m-d');

        return [
            'Nome' => 'required',
            'Sobrenome' => 'required',
            'Email' => 'required|email',
            'Dt' => "required|before:{$hoje}",
            'Escolaridade' => 'required'
        ];

       
    }

    //Aplica o feedback das regras
    public function Feedback(){
        return[
            'required' => "O campo :attribute precisa ser preenchido!",
            'email' => 'email invalido',
            'Dt' => 'A data de nascimento não pode ser maior que o dia de hoje'
        ];
    }

}
