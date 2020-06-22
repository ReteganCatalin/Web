<?php


class MediaFile 
{
    public $id;
    public $title;
    public $format;
    public $genre;
    public $location;

    /**
     * MediaFile constructor.
     * @param $id
     * @param $title
     * @param $format
     * @param $genre
     * @param $location
     */
    public function __construct($id, $title, $format, $genre, $location)
    {
        $this->id = $id;
        $this->title = $title;
        $this->format = $format;
        $this->genre = $genre;
        $this->location = $location;
    }


    public function getId()
    {
        return $this->id;
    }

    /**
     * @return mixed
     */
    public function getTitle()
    {
        return $this->title;
    }

    /**
     * @param mixed $title
     */
    public function setTitle($title)
    {
        $this->title = $title;
    }

    /**
     * @return mixed
     */
    public function getFormat()
    {
        return $this->format;
    }

    /**
     * @param mixed $format
     */
    public function setFormat($format)
    {
        $this->format = $format;
    }

    /**
     * @return mixed
     */
    public function getGenre()
    {
        return $this->genre;
    }

    /**
     * @param mixed $genre
     */
    public function setGenre($genre)
    {
        $this->genre = $genre;
    }

    /**
     * @return mixed
     */
    public function getLocation()
    {
        return $this->location;
    }

    /**
     * @param mixed $location
     */
    public function setLocation($location)
    {
        $this->location = $location;
    }





}