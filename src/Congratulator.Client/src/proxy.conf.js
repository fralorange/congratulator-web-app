const PROXY_CONFIG = [
  {
    context: [
      "/Congratulator/api/birthdaydate",
    ],
    target: "https://localhost:7265",
    secure: false
  }
];

module.exports = PROXY_CONFIG;
