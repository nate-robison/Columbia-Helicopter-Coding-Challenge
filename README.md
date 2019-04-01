# CHI Mobile Code Challenge

Congratulations on making it to the next phase of your application with Columbia Helicopters! At this stage, we would like to complete a code challenge. This code challenge is a way for us to analyze our applicants' proficiency and gives you a chance to exhibit your skillset.

For this challenge, you will be submitting a small Xamarin.Forms project. While the project domain is entirely fictional, the code that you will be writing has many parallels to the code we write every day here at CHI. Thus, please write and structure your code with the same care that you would apply in a real-world business application.

## Getting Started

To get started, clone this repository. Follow the instructions below to complete the project. Make sure that you commit all of the changes you make, then push the repository to your own remote repository and send us the link once you are finished.

Be sure to view the screenshots of each view before getting started. They depict what your resulting view should look like. You can improve upon the UI if you'd like, but your content should match the screenshots.

## What to Do

- Use as much (or as little) of the provided solution to produce the requested product
- Use Xamarin.Forms 3.x
- Use the MVVM pattern

## What Not to Do

- Do not use a 3rd-party MVVM framework
    - Though these frameworks can simplify things like navigation and view model resolution, we need you to use vanilla Xamarin.Forms
- Your time is important, so please don't spend an unnecessary amount of time making your app "perfect"

## Data Source

You will be working with a public RESTful API that JSON results based on the Star Wars universe. Use the [The Star Wars API](https://swapi.co/documentation) to populate each view with the prescribed content.

## Views to Create

### StarshipsView

This page should contain a list of starships from the SWAPI API. Each starship's list item should be tappable. Once tapped, a view of the ship should open in a new view (see **StarshipView** below).

In each list item (starship), please list the follwing properties:

- Name
- Starship Class

The list should be sorted alphabetically by the starships' names.

[Screenshot of Desired UI](https://drive.google.com/file/d/1gDVEVG9HH5i6g3CYCrQkG4ZlWl3fkx7D/view?usp=sharing)

### StarshipView

As an overview of the starship, this view should list basic information about the selected ship.

Include the following properties and their values:

- Name
- Model
- Starship Class
- Manufacturer
- Cost in Credits
- Length (meters)
- Crew
- Passengers
- Max Atmosphering Speed
- Hyperdrive Rating
- MGLT (megalights per hour)
- Cargo Capacity (kilograms)
- Consumables

This view should contain an image obtained from the StarshipImageService service. This service is already available in the solution included in this repository.

[Screenshot of Desired UI](https://drive.google.com/file/d/1imOnzk-b_Vga0_uO6eDPQPv5_w_QnDAo/view?usp=sharing)

## Notes

Please perform as many tasks for this challenge that you can. If there are parts of the challenge that you are not able to complete, please replace the task with something you feel more comfortable with.

Due to the Xamarin.Forms requirement for a Mac device, which many developers do not have at home, this challenge will only focus on the Android project. We will not be reviewing the iOS project in your solution.

If you have any questions please don't hesitate to ask!

Have fun and good luck!