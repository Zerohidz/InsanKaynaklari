using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;

public class NameGenerator : SingletonMB<NameGenerator>
{
    private Dictionary<Race, NameSet> _nameSets;

    protected override void Awake()
    {
        base.Awake();
        if (IsBeingDestroyed)
            return;

        _nameSets = new() {
            {Race.Russsian,new NameSet(_russianMaleNames, _russianFemaleNames, _russianSurnames )},
            {Race.Turkish,new NameSet(_turkishMaleNames, _turkishFemaleNames, _turkishSurnames)},
            {Race.Arab,new NameSet(_arabMaleNames, _arabFemaleNames, _arabSurnames)},
            {Race.German,new NameSet(_germanMaleNames, _germanFemaleNames, _germanSurnames)},
            {Race.American ,new NameSet(_americanMaleNames, _americanFemaleNames, _americanSurnames) },
        };
    }

    public string GetRandomName(Race race, Gender gender)
    {
        string name = "";
        bool isMale = gender == Gender.Male ? true : false;
        NameSet nameSet = _nameSets[race];
        if (race == Race.Turkish)
            name = GetRandomDoubleNameWithProbability(nameSet, isMale);
        else
            name = GetRandomDoubleNameFrom(nameSet, isMale);

        name += " " + GetRandomNameFrom(nameSet.Surnames);
        return name;
    }

    private string GetRandomDoubleNameWithProbability(NameSet nameSet, bool isMale)
    {
        if (!nameSet.HasNameProbabilities)
            return null;

        bool isDoubleName = BoolHelper.GetRandom();
        string name = "";
        if (isDoubleName)
        {
            name = GetRandomNameWithProbability(nameSet, isMale);
            name += " " + GetRandomNameFrom(nameSet, isMale, name);
        }
        else
        {
            name = GetRandomNameFrom(nameSet, isMale);
        }
        return name;
    }

    private string GetRandomDoubleNameFrom(NameSet nameSet, bool isMale)
    {
        bool isDoubleName = BoolHelper.GetRandom();
        string name = "";
        if (isDoubleName)
        {
            name = GetRandomNameFrom(nameSet, isMale);
            name += " " + GetRandomNameFrom(nameSet, isMale, name);
        }
        else
        {
            name = GetRandomNameFrom(nameSet, isMale);
        }
        return name;
    }

    private string GetRandomNameFrom(NameSet nameSet, bool isMale, string nameToExclude = null)
    {
        var name = "";
        if (isMale)
            name = GetRandomNameFrom(nameSet.MaleNames, nameToExclude);
        else
            name = GetRandomNameFrom(nameSet.FemaleNames, nameToExclude);

        return name;
    }

    private string GetRandomNameFrom(string[] array, string nameToExclude = null)
    {
        if (nameToExclude != null)
        {
            var list = new List<string>(array);
            list.Remove(nameToExclude);

            return list[Random.Range(0, list.Count)];
        }
        else
        {
            return array[Random.Range(0, array.Length)];
        }
    }

    // The calculation of probability can slow down the process of getting the name
    // so we can precalculate the total probabilities on each step of the summation
    private string GetRandomNameWithProbability(NameSet nameSet, bool isMale)
    {
        if (!nameSet.HasNameProbabilities)
            return null;

        (string name, float probability)[] nameArray;
        if (isMale)
            nameArray = nameSet.MaleNamesWithProbabilities;
        else
            nameArray = nameSet.FemaleNamesWithProbabilities;

        float probabilitySum = nameArray.Sum(x => x.probability);
        float randomFloat = Random.Range(0f, probabilitySum);

        float sum = 0;
        foreach (var item in nameArray)
        {
            sum += item.probability;
            if (sum >= randomFloat)
                return item.name;
        }

        // return the first random element if any error occurs
        Debug.Log("Random calculation failed!");
        return nameArray[0].name;
    }

    private struct NameSet
    {
        public bool HasNameProbabilities => MaleNamesWithProbabilities.Any();

        public (string, float)[] MaleNamesWithProbabilities;
        public (string, float)[] FemaleNamesWithProbabilities;
        public string[] MaleNames;
        public string[] FemaleNames;
        public string[] Surnames;

        public NameSet((string, float)[] maleNamesWithProbabilities, (string, float)[] feMaleNamesWithProbabilities, string[] surnames)
        {
            MaleNamesWithProbabilities = maleNamesWithProbabilities;
            FemaleNamesWithProbabilities = feMaleNamesWithProbabilities;
            Surnames = surnames;
            MaleNames = maleNamesWithProbabilities.Select(p => p.Item1).ToArray();
            FemaleNames = feMaleNamesWithProbabilities.Select(p => p.Item1).ToArray();
        }

        public NameSet(string[] maleNames, string[] femaleNames, string[] surnames) : this()
        {
            MaleNames = maleNames;
            FemaleNames = femaleNames;
            Surnames = surnames;
        }
    }

    private readonly (string, float)[] _turkishMaleNames = {
        ("Ahmet", 0.0406f), ("Ali", 0.0394f), ("Mehmet", 0.0357f), ("Mustafa", 0.0318f), ("İbrahim", 0.0229f),
        ("Osman", 0.0184f), ("Hüseyin", 0.0169f), ("Hasan", 0.0153f), ("Murat", 0.0148f), ("Yusuf", 0.0139f),
        ("Emre", 0.0129f), ("Kemal", 0.0127f), ("Ertuğrul", 0.0125f), ("Cemal", 0.0121f), ("Yunus", 0.0119f),
        ("Taha", 0.0116f), ("Akın", 0.0115f), ("Uğur", 0.0113f), ("Enes", 0.0109f), ("Ekrem", 0.0106f),
        ("Emin", 0.0105f), ("Fatih", 0.0102f), ("Halil", 0.0101f), ("Yakup", 0.0101f), ("Ercan", 0.0098f),
        ("Hakan", 0.0096f), ("Furkan", 0.0093f), ("Ömer", 0.0093f), ("Adem", 0.0092f), ("Can", 0.0092f),
        ("Yasin", 0.0091f), ("Fikret", 0.0090f), ("Efe", 0.0089f), ("Necmettin", 0.0088f), ("Abdullah", 0.0087f),
        ("Berk", 0.0086f), ("Selim", 0.0085f), ("Hacı", 0.0084f), ("Mert", 0.0083f), ("Serdar", 0.0083f),
        ("Umut", 0.0083f), ("Ege", 0.0082f), ("Salih", 0.0082f), ("Yiğit", 0.0082f), ("Yaşar", 0.0081f),
        ("Nihat", 0.0080f), ("Kenan", 0.0079f), ("Cemil", 0.0078f), ("Barış", 0.0077f), ("Serkan", 0.0076f),
        ("Şahin", 0.0076f), ("Arif", 0.0075f), ("Emrah", 0.0075f), ("Aydın", 0.0074f), ("Yavuz", 0.0074f),
        ("Nuri", 0.0073f), ("Erdal", 0.0072f), ("Yılmaz", 0.0072f), ("Bülent", 0.0071f), ("Recep", 0.0071f),
        ("Samet", 0.0070f), ("Orhan", 0.0069f), ("Musa", 0.0068f), ("İsmail", 0.0067f), ("Metin", 0.0066f),
        ("Cengiz", 0.0065f), ("İlker", 0.0065f), ("Gökhan", 0.0064f), ("Galip", 0.0063f), ("Ali İhsan", 0.0063f),
        ("Tuncay", 0.0063f), ("Yıldırım", 0.0063f), ("Aykut", 0.0062f), ("Mikail", 0.0062f), ("Nihat", 0.0062f),
        ("Onur", 0.0062f), ("Selahattin", 0.0062f), ("Mücahit", 0.0061f), ("Necati", 0.0061f), ("Şevket", 0.0061f),
        ("Şenol", 0.0060f), ("Yalçın", 0.0060f), ("Koray", 0.0059f), ("Erhan", 0.0058f), ("Kadir", 0.0058f),
        ("Deniz", 0.0057f), ("Hakan", 0.0057f), ("Bora", 0.0056f), ("Cihan", 0.0056f), ("Sadık", 0.0056f),
        ("Fikri", 0.0055f), ("Ergin", 0.0054f), ("Orkun", 0.0054f), ("Zeki", 0.0054f), ("Bekir", 0.0053f),
        ("Fuat", 0.0053f), ("Hilmi", 0.0053f), ("Necmi", 0.0053f), ("Zafer", 0.0053f), ("Muharrem", 0.0052f),
        ("Mehdi", 0.0051f), ("Burak", 0.0050f), ("Ekrem", 0.0050f), ("Emin", 0.0050f), ("Gürkan", 0.0050f),
        ("Oktay", 0.0050f), ("Orhan Can", 0.0050f), ("Eren", 0.0049f), ("Rıdvan", 0.0049f), ("İzzet", 0.0048f),
        ("Yasir", 0.0048f), ("Bartu", 0.0047f), ("Hüseyin", 0.0047f), ("Taylan", 0.0047f), ("Abdurrahman", 0.0046f),
    };

    private readonly (string, float)[] _turkishFemaleNames = {
        ("Açelya", 0.03f), ("Aslı", 0.09f), ("Ayşe", 0.12f), ("Bade", 0.02f), ("Begüm", 0.03f),
        ("Belgin", 0.01f), ("Belgin", 0.02f), ("Berna", 0.01f), ("Berrin", 0.03f), ("Betül", 0.01f),
        ("Beyza", 0.02f), ("Binnur", 0.01f), ("Buse", 0.05f), ("Canan", 0.01f), ("Cansu", 0.02f),
        ("Cemre", 0.02f), ("Ceyda", 0.01f), ("Ceylan", 0.03f), ("Çağla", 0.02f), ("Damla", 0.04f),
        ("Derya", 0.07f), ("Didem", 0.01f), ("Dilek", 0.03f), ("Ebru", 0.06f), ("Eda", 0.02f),
        ("Ela", 0.02f), ("Elif", 0.08f), ("Emel", 0.01f), ("Esin", 0.02f), ("Esra", 0.05f),
        ("Ezgi", 0.03f), ("Fadime", 0.01f), ("Fatma", 0.10f), ("Ferda", 0.01f), ("Feride", 0.02f),
        ("Gamze", 0.03f), ("Gizem", 0.04f), ("Gül", 0.01f), ("Gülçin", 0.01f), ("Gülay", 0.02f),
        ("Gülnur", 0.01f), ("Gülşah", 0.02f), ("Gülten", 0.01f), ("Güzin", 0.01f), ("Hale", 0.01f),
        ("Hande", 0.04f), ("Hasibe", 0.01f), ("Hatice", 0.06f), ("Hazal", 0.03f), ("Hilal", 0.04f),
        ("Ilgın", 0.01f), ("Irmak", 0.02f), ("Kader", 0.02f), ("Kamile", 0.01f), ("Kübra", 0.05f),
        ("Lale", 0.02f), ("Merve", 0.08f), ("Mine", 0.02f), ("Nagehan", 0.01f), ("Nalan", 0.01f),
        ("Necmiye", 0.01f), ("Neslihan", 0.04f), ("Nida", 0.01f), ("Nihal", 0.01f), ("Nur", 0.03f),
        ("Nuran", 0.01f), ("Nuray", 0.03f), ("Özge", 0.03f), ("Özlem", 0.06f), ("Pınar", 0.05f),
        ("Rabia", 0.01f), ("Reyhan", 0.02f), ("Sabiha", 0.01f), ("Sadık", 0.01f), ("Seda", 0.03f),
        ("Selda", 0.02f), ("Sevgi", 0.02f), ("Sevil", 0.01f), ("Sevim", 0.02f), ("Sezen", 0.01f),
        ("Sibel", 0.03f), ("Simge", 0.01f), ("Sinem", 0.05f), ("Songül", 0.02f), ("Şebnem", 0.01f),
        ("Şenay", 0.01f), ("Şule", 0.01f), ("Tuğba", 0.02f), ("Tülin", 0.01f), ("Tülay", 0.01f),
        ("Türkan", 0.01f), ("Ülkü", 0.01f), ("Ümit", 0.01f), ("Sümeyye", 0.01f), ("Yasemin", 0.06f),
        ("Yelda", 0.01f), ("Yeliz", 0.02f), ("Yüksel", 0.01f), ("Zarife", 0.01f), ("Zehra", 0.04f),
        ("Zekiye", 0.01f),
    };

    private readonly string[] _turkishSurnames = new string[] {
        "Acar", "Akbay", "Akgün", "Aksoy", "Aktaş", "Akyüz", "Akman", "Arslan",
        "Atalay", "Atasoy", "Aydoğan", "Aydın", "Aygün", "Aykut", "Aypar", "Aysel",
        "Aysu", "Ayyıldız", "Akben", "Aytaş", "Babacan", "Bayar", "Bayer", "Baykara",
        "Bayrak", "Bayram", "Baysal", "Bektaş", "Beşerler", "Beyaz", "Bilge",
        "Birinci", "Bora", "Bozkurt", "Can", "Canan", "Cengiz", "Çelik", "Demir",
        "Deniz", "Doğan", "Duman", "Durak", "Duru", "Duygu", "Erdem", "Erdinç",
        "Erdoğan", "Erbakan", "Erol", "Ersöz", "Gür", "Güner", "Güneş", "Gürsel",
        "Güzel", "İlhan", "İnan", "Kahraman", "Kaplan", "Kara", "Karaca", "Karakaya",
        "Karakuş", "Kasap", "Kaya", "Latifoğlu", "Kıvanç", "Koş", "Korkmaz", "Kurt",
        "Sevilmiş", "Mutlu", "Özcan", "Özdemir", "Özen", "Özyürek", "Sönmez",
        "Süleyman", "Şahin", "Şanlı", "Şen", "Şimşek", "Taş", "Tuncel", "Türk",
        "Uzun", "Uzman", "Yalçın", "Yaman", "Yapıcı", "Yavuz", "Yıldırım",
        "Yılmaz", "Yaldız", "Yıldız", "Diler", "Bestil",
    };

    private readonly string[] _germanMaleNames = new string[] {
        "Alexander", "Andreas", "Anton", "Armin", "Axel", "Benjamin", "Bernd", "Christian", "Christopher", "Daniel",
        "David", "Dirk", "Dominik", "Eckhard", "Eduard", "Egon", "Emil", "Erhard", "Ernst", "Fabian", "Felix",
        "Florian", "Frank", "Friedrich", "Georg", "Gerald", "Gerhard", "Gernot", "Gregor", "Günter", "Hans",
        "Harald", "Heiko", "Heinz", "Helmut", "Henning", "Herbert", "Hermann", "Horst", "Jan", "Jens", "Joachim",
        "Johannes", "Jonas", "Jörg", "Jürgen", "Kai", "Karsten", "Klaus", "Konrad", "Lars", "Leo", "Lukas",
        "Manfred", "Marcus", "Markus", "Martin", "Matthias", "Maximilian", "Michael", "Moritz", "Nico", "Niklas",
        "Oliver", "Patrick", "Paul", "Peter", "Philipp", "Rainer", "Ralf", "Reinhard", "René", "Roland", "Rolf",
        "Sebastian", "Stefan", "Thomas", "Thorsten", "Timo", "Tobias", "Uwe", "Volker", "Walter", "Werner",
    };

    private readonly string[] _germanFemaleNames = new string[] {
        "Alexandra", "Alina", "Amelie", "Anastasia", "Angela", "Angelika", "Anja", "Anna", "Anne", "Antje", "Astrid",
        "Barbara", "Beate", "Bianca", "Brigitte", "Carina", "Carla", "Caroline", "Christa", "Christiane", "Christina",
        "Claudia", "Constanze", "Dagmar", "Daniela", "Diana", "Doris", "Edith", "Elena", "Elisabeth", "Ella", "Ellen",
        "Elke", "Emilia", "Emma", "Erika", "Esther", "Eva", "Felicitas", "Franziska", "Gabriele", "Gisela", "Hanna",
        "Hannelore", "Heidi", "Heike", "Helena", "Helene", "Helga", "Henriette", "Ina", "Ines", "Inga", "Ingrid",
        "Irene", "Isabel", "Jacqueline", "Jana", "Janina", "Jasmin", "Jennifer", "Jessica", "Johanna", "Julia",
        "Juliane", "Karen", "Karina", "Karin", "Karla", "Katarina", "Katharina", "Kathrin", "Katja", "Kerstin",
        "Kim", "Klara", "Kristina", "Laura", "Lea", "Lena", "Leonie", "Linda", "Lisa", "Luisa", "Magdalena", "Maike",
        "Manuela", "Mareike", "Maria", "Marianne", "Marie", "Marion", "Marta", "Martina", "Mathilde", "Melanie",
        "Michaela", "Monika", "Nadine", "Natascha", "Nicole", "Nina", "Petra", "Renate", "Rita", "Sabine", "Sandra",
        "Sarah", "Silke", "Simone", "Sonja", "Sophie", "Stefanie", "Susanne", "Tanja", "Tina", "Ursula", "Ute",
        "Vanessa", "Veronika",
    };

    private readonly string[] _germanSurnames = new string[] {
        "Abel", "Baumann", "Becker", "Bergmann", "Berger", "Beyer", "Böhm", "Brandt", "Braun", "Busch",
        "Dietrich", "Eberhardt", "Eckert", "Engel", "Fischer", "Franke", "Freitag", "Friedrich", "Gärtner",
        "Gerhardt", "Götz", "Graf", "Gruber", "Haas", "Hahn", "Hartmann", "Heinrich", "Heller", "Herrmann",
        "Hoffmann", "Holz", "Huber", "Jäger", "Kaiser", "Keller", "Klein", "König", "Krause", "Krüger",
        "Kuhn", "Kunz", "Lang", "Lehmann", "Lorenz", "Ludwig", "Maier", "Mayer", "Meier", "Meyer", "Müller",
        "Neumann", "Peters", "Pfeiffer", "Richter", "Ritter", "Roth", "Sauer", "Schäfer", "Schaller", "Schindler",
        "Schmidt", "Schneider", "Scholz", "Schreiber", "Schubert", "Schulz", "Schumacher", "Schuster", "Schwarz",
        "Seidel", "Simon", "Sommer", "Stahl", "Stein", "Thomas", "Vogel", "Wagner", "Weber", "Weiß", "Werner",
        "Winkler", "Wolf", "Wolff", "Ziegler", "Zimmermann",
    };


    private readonly string[] _americanMaleNames = new string[] {
        "Adam", "Andrew", "Anthony", "Austin", "Benjamin", "Blake", "Brandon", "Brian", "Cameron", "Charles",
        "Christian", "Christopher", "Cody", "Cole", "Connor", "Daniel", "David", "Derek", "Dominic", "Dylan",
        "Edward", "Elijah", "Eric", "Ethan", "Gabriel", "Gavin", "George", "Gregory", "Hunter", "Isaac",
        "Jack", "Jacob", "James", "Jason", "Jayden", "Jeremy", "Jesse", "John", "Jonathan", "Jordan",
        "Joseph", "Joshua", "Justin", "Kevin", "Kyle", "Landon", "Logan", "Lucas", "Mark", "Matthew",
        "Michael", "Nathan", "Nicholas", "Noah", "Patrick", "Paul", "Peter", "Phillip", "Raymond",
        "Richard", "Robert", "Ryan", "Samuel", "Scott", "Sean", "Stephen", "Steven", "Taylor", "Thomas",
        "Timothy", "Travis", "Trevor", "Tyler", "Victor", "Vincent", "William", "Wyatt", "Zachary",
    };

    private readonly string[] _americanFemaleNames = new string[] {
        "Abigail", "Alyssa", "Amanda", "Amber", "Amy", "Angelina", "Ashley", "Bethany", "Brittany", "Brooke",
        "Caitlin", "Caroline", "Cassandra", "Chelsea", "Christina", "Claire", "Courtney", "Crystal", "Danielle",
        "Destiny", "Elizabeth", "Emily", "Emma", "Erica", "Erin", "Gabrielle", "Hailey", "Haley", "Hannah",
        "Heather", "Isabella", "Jacqueline", "Jamie", "Jasmine", "Jennifer", "Jessica", "Jillian", "Jordan",
        "Julia", "Kaitlyn", "Katherine", "Katie", "Kayla", "Kelly", "Kelsey", "Kimberly", "Kristen", "Krystal",
        "Laura", "Lauren", "Lily", "Madison", "Makayla", "Megan", "Melissa", "Mia", "Michelle", "Morgan",
        "Natalie", "Olivia", "Paige", "Rachel", "Rebecca", "Samantha", "Sara", "Sarah", "Savannah", "Shannon",
        "Shelby", "Sierra", "Stephanie", "Summer", "Sydney", "Tara", "Taylor", "Tiffany", "Vanessa", "Victoria",
        "Whitney", "Zoe",
    };

    private readonly string[] _americanSurnames = new string[] {
        "Adams", "Anderson", "Baker", "Barnes", "Bell", "Brooks", "Brown", "Bryant", "Butler", "Campbell",
        "Carter", "Clark", "Coleman", "Collins", "Cook", "Cooper", "Cox", "Cruz", "Davis", "Diaz",
        "Edwards", "Evans", "Fisher", "Flores", "Foster", "Garcia", "Gomez", "Gonzalez", "Gray",
        "Green", "Hall", "Harris", "Hayes", "Henderson", "Hernandez", "Hill", "Howard", "Hughes",
        "Jackson", "James", "Jenkins", "Johnson", "Jones", "Kelly", "Kennedy", "Kim", "King",
        "Lee", "Lewis", "Lopez", "Martinez", "Miller", "Mitchell", "Moore", "Morgan", "Morris",
        "Murphy", "Nelson", "Nguyen", "Parker", "Perez", "Powell", "Ramirez", "Reed", "Richardson",
        "Rivera", "Roberts", "Rodriguez", "Rogers", "Ross", "Sanchez", "Sanders", "Scott", "Smith",
        "Stewart", "Taylor", "Thomas", "Thompson", "Torres", "Turner", "Walker", "Ward", "Washington",
        "Watson", "White", "Williams", "Wilson", "Wood", "Wright", "Young",
    };

    private readonly string[] _russianMaleNames = new string[] {
        "Aleksandr", "Alexey", "Anatoliy", "Andrei", "Anton", "Arkadiy", "Artem", "Bogdan", "Boris", "Danil",
        "Denis", "Dmitriy", "Eduard", "Egor", "Evgeniy", "Fedor", "Filipp", "Gavriil", "Georgiy", "Gleb",
        "Grigoriy", "Igor", "Ilya", "Ivan", "Kirill", "Konstantin", "Lev", "Maksim", "Mikhail", "Nikita",
        "Nikolay", "Oleg", "Pavel", "Petr", "Ruslan", "Semyon", "Sergey", "Stanislav", "Stepan", "Timofey",
        "Vadim", "Valentin", "Vasiliy", "Viktor", "Vladimir", "Vladislav", "Vyacheslav", "Yakov", "Yaroslav",
        "Yevgeniy", "Yuriy", "Anastasiy", "Antonin", "Borislav", "Daniil", "Demyan", "Egoriy", "Emelyan", "Eremey",
        "Faddey", "Fedorin", "Filippin", "Gennadiy", "Gerasim", "Glebin", "Gordey", "Grigoriyev", "Ignatiy", "Iosif",
        "Kapitolina", "Khariton", "Klavdiy", "Kuzma", "Lavrentiy", "Lazar", "Leonid", "Makar", "Mark", "Matvey",
        "Mitrofan", "Nestor", "Nikandr", "Nikifor", "Pafnutiy", "Pankrat", "Prokhor", "Rodion", "Rostislav", "Savva",
        "Saveliy", "Semyonov", "Sergeev", "Sidor", "Svyatoslav", "Terentiy", "Timur", "Trofim", "Ustin", "Varfolomey",
        "Varvara", "Vasilin", "Vassily", "Venedikt", "Vsevolod", "Yefim", "Yemelyanov", "Yermolay", "Yermolai", "Zahar",
    };

    private readonly string[] _russianFemaleNames = new string[] {
        "Alina", "Anastasiya", "Anna", "Antonina", "Arina", "Daria", "Darina", "Diana", "Dina", "Ekaterina",
        "Elizaveta", "Eva", "Galina", "Inna", "Irina", "Karina", "Kira", "Kseniya", "Larisa", "Lidiya",
        "Liliya", "Lyudmila", "Maria", "Mariya", "Marina", "Marta", "Nadezhda", "Nataliya", "Nina", "Oksana",
        "Olga", "Polina", "Raisa", "Regina", "Sofiya", "Svetlana", "Taisiya", "Tamara", "Tatiana", "Valentina",
        "Valeria", "Vasilisa", "Vera", "Veronika", "Viktoriya", "Violetta", "Yana", "Yaroslava", "Yelena", "Yulia",
        "Zinaida", "Zoya", "Aleksandra", "Anfisa", "Anzhelika", "Ariadna", "Bogdana", "Dariya", "Darya", "Dominika",
        "Elina", "Emiliya", "Gulnara", "Izabella", "Kamila", "Karolina", "Klara", "Ksenia", "Lada", "Leyla",
        "Lina", "Lydia", "Magdalena", "Margarita", "Mila", "Nika", "Nina", "Nora", "Roza", "Sofia",
        "Toma", "Varya", "Venera", "Vesta", "Yeva", "Yuliana", "Yuliya", "Zarina", "Zlata", "Zoya"
    };

    private readonly string[] _russianSurnames = new string[] {
        "Abramov", "Alexandrov", "Andreev", "Antonov", "Averin", "Bogdanov", "Borisov", "Chernov", "Danilov", "Davydov",
        "Denisov", "Dmitriev", "Efimov", "Egorov", "Fedorov", "Filippov", "Gavrilov", "Golubev", "Gorbachev", "Gordeev",
        "Gromov", "Ivanov", "Kalinin", "Karpov", "Kazakov", "Kharitonov", "Khokhlov", "Kuzmin", "Lebedev", "Lobanov",
        "Makarov", "Maksimov", "Mikhailov", "Morozov", "Nekrasov", "Nikitin", "Novikov", "Osipov", "Pavlov", "Petrov",
        "Popov", "Prokhorov", "Rogov", "Romanov", "Ryzhkov", "Savin", "Semenov", "Sergeev", "Sokolov", "Solovyov",
        "Sorokin", "Stepanov", "Suvorov", "Tarasov", "Titov", "Tkachev", "Tolstoy", "Ustinov", "Vasiliev", "Vishnevsky",
        "Volkov", "Vorobyov", "Yakovlev", "Yegorov", "Yermakov", "Zaitsev", "Zakharov", "Zhdanov", "Zhukov"
    };

    private readonly string[] _arabMaleNames = new string[] {
        "Abdullah", "Ahmed", "Ali", "Amir", "Anwar", "Asem", "Ayman", "Aziz", "Bassam", "Fadi",
        "Fahad", "Faisal", "Farid", "Firas", "Ghazi", "Hadi", "Hakim", "Hamid", "Hani", "Harun",
        "Hasan", "Hazim", "Hisham", "Husam", "Ibrahim", "Imad", "Ismail", "Jaber", "Jalal", "Jamal",
        "Jawad", "Kamal", "Khalid", "Maher", "Majid", "Malik", "Mamdouh", "Mansour", "Marwan",
        "Mazen", "Mehdi", "Mohammed", "Moussa", "Muhammad", "Munir", "Mustafa", "Nabil", "Nader",
        "Naji", "Nasir", "Nidal", "Omar", "Osama", "Rafiq", "Rami", "Rashid", "Saad", "Sabri",
        "Said", "Salah", "Salim", "Samir", "Saud", "Sharif", "Taher", "Talal", "Tariq", "Wael",
        "Walid", "Yahya", "Yaser", "Yassin", "Youssef", "Zakaria", "Ziad", "Zuhair",
    };

    private readonly string[] _arabFemaleNames = new string[] {
        "Abeer", "Afaf", "Aisha", "Alia", "Amal", "Amira", "Anfal", "Anoud", "Asma",
        "Aya", "Ayat", "Ayesha", "Aziza", "Banan", "Dalal", "Dana", "Dina", "Duha",
        "Fadia", "Fadwa", "Fahima", "Farida", "Faten", "Fatima", "Ghada", "Habiba",
        "Hala","Hadeel", "Hafsa","Halima", "Hana", "Hanadi", "Hanan", "Haneen", "Hasna",
        "Hayat", "Hiba", "Hind", "Iman", "Inas", "Jawaher", "Jihan", "Kawthar", "Khadija",
        "Lamia", "Leila", "Lina", "Maha", "Malak", "Manal", "Mariam", "Maryam", "Maya",
        "Mona", "Mouna", "Muna", "Nada", "Nadia", "Najat", "Nawal", "Nesrin", "Nihad",
        "Nisreen", "Nour", "Nuha", "Ola", "Rabab", "Rabia", "Rahma", "Rania", "Rasha",
        "Rawan", "Reem", "Riham", "Rima", "Rola", "Roula", "Saba", "Safia", "Sahar","Zainab",
        "Salma", "Samah", "Samia", "Sana", "Sara", "Shadia", "Shahd", "Shaima", "Shatha",
        "Siham", "Souad", "Sumaya", "Suzan", "Taghrid", "Wafa", "Yara", "Yasmin", "Zahra",
    };

    private readonly string[] _arabSurnames =  {
        "Al-Amiri", "Al-Ansari", "Al-Askari", "Al-Aswad", "Al-Awadhi", "Al-Azm", "Al-Bakr", "Al-Baroudi",
        "Al-Darweesh", "Al-Dosari", "Al-Fakhri", "Al-Farhan", "Al-Faris", "Al-Fatih", "Al-Ghamdi", "Al-Ghazi",
        "Al-Haddad", "Al-Haddawi", "Al-Halabi", "Al-Halwani", "Al-Hamad", "Al-Harbi", "Al-Hashemi", "Al-Hassan",
        "Al-Hayek", "Al-Hejji", "Al-Jaber", "Al-Jabri", "Al-Jarrah", "Al-Jasmi", "Al-Jawhari", "Al-Juhani",
        "Al-Karim", "Al-Kassim", "Al-Khalifa", "Al-Khaleel", "Al-Khateeb", "Al-Khouri", "Al-Khuzai", "Al-Madani",
        "Al-Mahdi", "Al-Majed", "Al-Makki", "Al-Mani", "Al-Mansoori", "Al-Masri", "Al-Mawla", "Al-Mohsen",
        "Al-Mubarak", "Al-Mudhafar", "Al-Mujahid", "Al-Mukhtar", "Al-Murad", "Al-Najjar", "Al-Nasr", "Al-Nasseri",
        "Al-Omari", "Al-Qadi", "Al-Qasim", "Al-Qassab", "Al-Quraishi", "Al-Rashid", "Al-Sabbagh", "Al-Saif",
        "Al-Salim", "Al-Saqqaf", "Al-Sarraf", "Al-Shafi", "Al-Shammari", "Al-Shamsi", "Al-Sharif", "Al-Shatti",
        "Al-Shehhi", "Al-Sheikh", "Al-Shuraifi", "Al-Sibai", "Al-Sudairi", "Al-Sufyani", "Al-Suhaimi", "Al-Tamimi",
        "Al-Thani", "Al-Turki", "Al-Wahabi", "Al-Wazzan", "Al-Yami", "Al-Yousef", "Al-Zaidi", "Al-Zakwani",
        "Al-Zayani", "Al-Zuhairi",
    };
}