import React, { useState, useEffect } from "react";
import axios from "axios";
import Ride from "../Ride/Ride";

const Rides = () => {
  const [rides, setRides] = useState([]);
  const [renderedItems, setRenderedItems] = useState([]);

  useEffect(() => {
    const fetchRides = async () => {
      const { data } = await axios.get("https://localhost:7014/rides", {
        params: {
          withPrice: true,
        },
      });

      setRides(data.result);
    };
    fetchRides();
  }, []);

  useEffect(() => {
    const r = rides.map((ride) => {
      return <Ride key={ride.id} {...ride} />;
    });
    setRenderedItems(r);
  }, [rides]);

  return <div className="ui piled segments app"> {renderedItems} </div>;
};

export default Rides;
