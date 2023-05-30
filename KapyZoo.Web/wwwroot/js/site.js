// Get the game container element
const gameContainer = document.getElementById('game-container');

// Get the capybara element
const capybara = document.querySelector('.capybara');

// Get the score and timer elements
const scoreElement = document.getElementById('score');
const timerElement = document.getElementById('timer');

// Add event listener for mouse click on the capybara element
capybara.addEventListener('click', handleCapybaraClick);

// Function to handle capybara click event
function handleCapybaraClick(event) {
    if (!capybara.classList.contains('animated')) {
        capybara.classList.add('animated');
        updateScore();

        // Remove 'animated' class after 1 second (adjust as needed)
        setTimeout(() => {
            capybara.classList.remove('animated');
        }, 1);
    }
}

// Initialize score and game duration
let score = 0;
const gameDuration = 30; // 30 seconds

// Function to update score
function updateScore() {
    score++;
    scoreElement.textContent = score;
}

// Move capybara randomly within the game container
function moveCapybara() {
    const gameContainerWidth = gameContainer.clientWidth - capybara.clientWidth;
    const gameContainerHeight = gameContainer.clientHeight - capybara.clientHeight;
    const randomX = Math.floor(Math.random() * gameContainerWidth);
    const randomY = Math.floor(Math.random() * gameContainerHeight);

    capybara.style.left = `${randomX}px`;
    capybara.style.top = `${randomY}px`;

    setTimeout(moveCapybara, 650); // Move capybara every 2 seconds
    if (timeLeft == 0) {
        setTimeout(moveCapybara,);
    }
}

// Timer
let timeLeft = gameDuration;

function updateTimer() {
    timerElement.textContent = timeLeft;
}

function startTimer() {
    updateTimer();

    const timerId = setInterval(() => {
        timeLeft--;

        if (timeLeft < 0) {
            clearInterval(timerId);
            endGame();
        } else {
            updateTimer();
        }
    }, 1000);
}

function endGame() {
    capybara.removeEventListener('click', handleCapybaraClick);
    capybara.style.pointerEvents = 'none';
    capybara.classList.add('animated');
}

// Start the game
startTimer();
moveCapybara();