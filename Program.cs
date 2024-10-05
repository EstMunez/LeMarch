// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

// Tableau pour stocker les fruits (maximum 5 fruits)
        string[] panier = new string[5];
        int compteurFruits = 0; // Compteur pour le nombre de fruits dans le panier
        string choix;

        do
        {
            // Affichage du menu
            Console.WriteLine("\n===== Jeu de gestion du panier de fruits =====");
            Console.WriteLine("1. Ajouter un fruit");
            Console.WriteLine("2. Retirer un fruit");
            Console.WriteLine("3. Afficher le panier");
            Console.WriteLine("4. Rechercher un fruit");
            Console.WriteLine("5. Quitter");
            Console.Write("Choisissez une option (1-5) : ");
            choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    // Ajouter un fruit
                    if (compteurFruits < 5)
                    {
                        Console.Write("Entrez le nom du fruit à ajouter : ");
                        string fruit = Console.ReadLine();
                        
                        // Vérification des doublons
                        if (Array.Exists(panier, f => f == fruit))
                        {
                            Console.WriteLine("Erreur : Le fruit est déjà dans le panier !");
                        }
                        else
                        {
                            panier[compteurFruits] = fruit;
                            compteurFruits++;
                            Console.WriteLine(fruit + " a été ajouté au panier.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Erreur : Le panier est plein (5 fruits maximum) !");
                    }
                    break;

                case "2":
                    // Retirer un fruit
                    if (compteurFruits > 0)
                    {
                        Console.Write("Entrez le nom du fruit à retirer : ");
                        string fruitARetirer = Console.ReadLine();
                        
                        bool fruitTrouve = false;
                        for (int i = 0; i < panier.Length; i++)
                        {
                            if (panier[i] == fruitARetirer)
                            {
                                panier[i] = null;
                                compteurFruits--;
                                fruitTrouve = true;
                                Console.WriteLine(fruitARetirer + " a été retiré du panier.");
                                // Réorganiser le panier pour combler l'espace vide
                                for (int j = i; j < panier.Length - 1; j++)
                                {
                                    panier[j] = panier[j + 1];
                                }
                                panier[panier.Length - 1] = null;
                                break;
                            }
                        }
                        
                        if (!fruitTrouve)
                        {
                            Console.WriteLine("Erreur : Le fruit n'est pas dans le panier.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Le panier est vide, aucun fruit à retirer.");
                    }
                    break;

                case "3":
                    // Afficher le panier
                    Console.WriteLine("Fruits dans le panier :");
                    if (compteurFruits == 0)
                    {
                        Console.WriteLine("Le panier est vide.");
                    }
                    else
                    {
                        for (int i = 0; i < panier.Length; i++)
                        {
                            if (panier[i] != null)
                            {
                                Console.WriteLine("- " + panier[i]);
                            }
                        }
                    }
                    break;

                case "4":
                    // Rechercher un fruit
                    Console.Write("Entrez le nom du fruit à rechercher : ");
                    string fruitARechercher = Console.ReadLine();
                    if (Array.Exists(panier, f => f == fruitARechercher))
                    {
                        Console.WriteLine(fruitARechercher + " est dans le panier.");
                    }
                    else
                    {
                        Console.WriteLine(fruitARechercher + " n'est pas dans le panier.");
                    }
                    break;

                case "5":
                    // Quitter
                    Console.WriteLine("Merci d'avoir joué !");
                    break;

                default:
                    Console.WriteLine("Erreur : Option non valide, veuillez réessayer.");
                    break;
            }

        } while (choix != "5");