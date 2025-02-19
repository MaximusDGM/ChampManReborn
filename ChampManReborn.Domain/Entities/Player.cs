namespace ChampManReborn.Domain.Entities;

public class Player : Person
{
    public new int Id { get; set; }
    public int SquadNumber { get; set; }
    public int CurrentAbility { get; set; }
    public int PotentialAbility { get; set; }
    public short HomeReputation { get; set; }
    public short CurrentReputation { get; set; }
    public short WorldReputation { get; set; }
    public int Goalkeeper { get; set; }
    public int Sweeper { get; set; }
    public int Defender { get; set; }
    public int DefensiveMidfielder { get; set; }
    public int Midfielder { get; set; }
    public int AttackingMidfielder { get; set; }
    public int Attacker { get; set; }
    public int WingBack { get; set; }
    public int RightSide { get; set; }
    public int LeftSide { get; set; }
    public int Central { get; set; }
    public int FreeRole { get; set; }
    public int Acceleration { get; set; }
    public int Aggression { get; set; }
    public int Agility { get; set; }
    public int Anticipation { get; set; }
    public int Balance { get; set; }
    public int Bravery { get; set; }
    public int Consistency { get; set; }
    public int Decisions { get; set; }
    public int Leadership { get; set; }
    public int Positioning { get; set; }
    public int Vision { get; set; }
    public int WorkRate { get; set; }
    public int Stamina { get; set; }
    public int Strength { get; set; }
    public int NaturalFitness { get; set; }
    public int Jumping { get; set; }
    public int Pace { get; set; }
    public int Reflexes { get; set; }
    public int Dribbling { get; set; }
    public int Finishing { get; set; }
    public int FreeKicks { get; set; }
    public int Crossing { get; set; }
    public int Tackling { get; set; }
    public int Marking { get; set; }
    public int Passing { get; set; }
    public int Heading { get; set; }
    public int Penalties { get; set; }
    public int Corners { get; set; }
    public int Technique { get; set; }
    public int LeftFoot { get; set; }
    public int RightFoot { get; set; }
    public int Morale { get; set; }
}