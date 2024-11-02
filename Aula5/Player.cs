using Godot;
using System;

public partial class Player : CharacterBody2D
{

	//Defenir a velocidade das personagens;
    private Vector2 _speed = new Vector2(400,0);

	//Criar força de salto
	private float _jumpvelocity = -600.0f;

	//Força de gravidade
	private float gravity = 1000.0f;

	//Referencia ao Sprite
	private Sprite2D _sprite;

	private Vector2 _velocity = Vector2.Zero;

    //Function to check if Player sprite is on Floor
	private bool isonFloor()
	{
		return _sprite.Position.Y >= 350;

	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//
		_sprite = GetNode<Sprite2D>("Sprite2D");
	}

    public  override void _Input(InputEvent @event)
	{
       GD.Print(@event.AsText());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//Atualiza a posição do personagem com base na velocidade e no tempo
		_sprite.Position += _speed * (float)delta;

		//Aplicação da gravidade ao jogador 
		_velocity.Y += gravity * (float)delta;

        //Salta se a tecla up for presionada e tiver no chão
		if(isonFloor() && Input.IsActionJustPressed("ui_up"))
        {
			_velocity.Y = _jumpvelocity;
		}

		_sprite.Position += _velocity * (float)delta;

        // Se o personagem ultrapassar a posição X de 1000
        if (_sprite.Position.X > 1000)
		{
            //Reposiciona o personagem na posição inicial
			_sprite.Position = new Vector2(-100, 350);
			_jumpvelocity = 0;
		}

        //Se o personagem estiver abaixo do chão
		if (_sprite.Position.Y > 350)
		{
			//o sprite fica com a velocidade nula e com a posição de 350 no eixo y
			_sprite.Position = new Vector2(_sprite.Position.Y, 350);
			_velocity.Y = 0;
		}
	}
}
