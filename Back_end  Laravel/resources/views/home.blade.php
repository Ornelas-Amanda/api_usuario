



@foreach($dados as $chave)
{{$chave->Nome}} </br>
{{$chave->Sobrenome}} </br>
{{$chave->Email}} </br>
{{$chave->Dt}} </br>
{{$chave->Escolaridade}} </br>
<button class="botao"><a href="{{route('excluir',$chave->id)}}">Excluir</a></button></br>
@endforeach

