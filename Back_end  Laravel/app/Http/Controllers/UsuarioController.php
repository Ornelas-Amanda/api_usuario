<?php

namespace App\Http\Controllers;

use App\Models\Usuario;
use App\Http\Requests\StoreUsuarioRequest;
use App\Http\Requests\UpdateUsuarioRequest;

class UsuarioController extends Controller
{
    protected $usuario;

    //Construtor
    public function __construct(Usuario $usuario)
    {
        $this->usuario = $usuario;
    }
    /**
     * Display a listing of the resource.
     */

     //Retorna todos os dados cadastrados em usuario e seu status
    public function index()
    {
        $usuarios = $this->usuario::all();       
        
       return  response()->json($usuarios, 201) ;
    }

    

    /**
     * Store a newly created resource in storage.
     */

    //Inserindo dados no banco
    public function store(StoreUsuarioRequest $request)
    {
       
        //validando request com as regras que foram definidas em usuário
        $request->validate($this->usuario->Regras(), $this->usuario->Feedback());

        //Inserindo registro do usuario 
        $usuario = $this->usuario->create($request->all());

        return  response()->json($usuario, 201) ;
    }

    /**
     * Display the specified resource.
     */

     //Consulta somente um único id
    public function show($id)
    {
        $usuario = $this->usuario->find($id);

        //se o usuário não existir, retorna com uma mensagem de erro e status 404
        if(is_null($usuario)){
            return response()->json( ['erro' => "Usuario não existe"],404) ;
        }
        return  response()->json($usuario,200);
    }


    /**
     * Update the specified resource in storage.
     */

     //Atualiza os dados de somente um id
    public function update(UpdateUsuarioRequest $request, $id)
    {
        $usuario = $this->usuario->find($id);

        //se o usuário não existir, retorna com uma mensagem de erro e status 404
        if(is_null($usuario)){
            return response()->json( ['erro' => "Usuario desconhecido, Impossivel atualizar"],404) ;
        }
         //validando request com as regras que foram definidas em usuário
        $request->validate($this->usuario->Regras(), $this->usuario->Feedback());

        $usuario->update($request->all()) ;
        
        return  response()->json($usuario,200) ;
    }

    /**
     * Remove the specified resource from storage.
     */

     //Deleta as informações de um usuário 
    public function destroy($id)
    {
       
        $usuario = $this->usuario->find($id);

        //se o usuário não existir, retorna com uma mensagem de erro e status 404
        if(is_null($usuario)){
            return response()->json(['erro' => "Usuario desconhecido, Impossivel deletar"], 404);
        }

        $usuario->delete();
       

        return  response()->json(['msg'=> 'Usuario removido'],200) ;
    }
}
