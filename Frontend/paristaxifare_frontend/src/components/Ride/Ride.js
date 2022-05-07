import React, { useState } from "react";

import "./Ride.css";

const Ride = ({ id, distance, startTime, duration, price }) => {
  const [isClicked, setIsClicked] = useState(false);
  const showAlert = () => {
    const endTime = new Date(startTime);
    endTime.setSeconds(endTime.getSeconds() + duration);
    const durationText = new Date(duration * 1000).toISOString().slice(11, 19);
    alert(`${durationText} - ${endTime.toISOString()}`);
  };

  const showClicked = () => {
    setIsClicked(true);
  };

  const isBackgroundRed = (distance) => {
    return distance > 2;
  };

  return (
    <div
      className="ride ui segment"
      style={{ backgroundColor: isBackgroundRed(distance) ? "red" : "" }}
      onClick={() => {
        showClicked();
        showAlert();
      }}
    >
      Ride Id: {id} <h3 style={{ display: isClicked ? "inline" : "none" }}>Clicked</h3><br />
      Distance: {distance} mi.<br />
      Start Time: {new Date(startTime).toISOString()} <br />
      Duration: {duration} <br />
      Price: {price}€<br />
    </div>
  );
};

export default Ride;
